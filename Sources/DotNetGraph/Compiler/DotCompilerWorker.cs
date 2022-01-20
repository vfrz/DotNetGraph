using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DotNetGraph.Compiler
{
    internal sealed class DotCompilerWorker : IDisposable
    {
        private static readonly Regex ValidIdentifierPattern = new Regex("^([a-zA-Z\\200-\\377_][a-zA-Z\\200-\\3770-9_]*|[-]?(.[0-9]+|[0-9]+(.[0-9]+)?))$");

        private readonly DotGraph _graph;
        private readonly TextWriter _writer;
        private readonly bool _disposeWriter;

        public bool Indented { get; }
        public bool FormatStrings { get; }

        public DotCompilerWorker(DotGraph graph, TextWriter writer, bool indented, bool formatStrings, bool disposeWriter = false)
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
            Indented = indented;
            FormatStrings = formatStrings;
            _disposeWriter = disposeWriter;
        }

        public void Dispose()
        {
            if (_disposeWriter)
                _writer?.Dispose();
        }

        public void Compile()
        {
            CompileGraph();
            _writer.Flush();
        }

        private void CompileGraph()
        {
            var indentationLevel = 0;

            if (_graph.Strict)
            {
                _writer.Write("strict ");
            }

            _writer.Write(_graph.Directed ? "digraph " : "graph ");

            _writer.Write($"{SurroundStringWithQuotes(FormatStrings ? FormatString(_graph.Identifier) : _graph.Identifier)} {{ ");

            _writer.AddIndentationNewLine(Indented);

            indentationLevel++;

            foreach (var element in _graph.Elements)
            {
                if (element is DotEdge edge)
                {
                    CompileEdge(edge, indentationLevel);
                }
                else if (element is DotNode node)
                {
                    CompileNode(node, indentationLevel);
                }
                else if (element is DotSubGraph subGraph)
                {
                    CompileSubGraph(subGraph, indentationLevel);
                }
                else if (element is DotString stringElement)
                {
                    CompileStringElement(stringElement, indentationLevel);
                }
                else
                {
                    throw new DotException($"Graph body can't contain element of type: {element.GetType()}");
                }
            }

            indentationLevel--;

            _writer.Write("}");
        }

        private void CompileSubGraph(DotSubGraph subGraph, int indentationLevel)
        {
            _writer.AddIndentation(Indented, indentationLevel);

            _writer.Write($"subgraph {SurroundStringWithQuotes(FormatStrings ? FormatString(subGraph.Identifier) : subGraph.Identifier)} {{ ");

            _writer.AddIndentationNewLine(Indented);

            indentationLevel++;

            CompileSubGraphAttributes(subGraph.Attributes, indentationLevel);

            foreach (var element in subGraph.Elements)
            {
                if (element is DotEdge edge)
                {
                    CompileEdge(edge, indentationLevel);
                }
                else if (element is DotNode node)
                {
                    CompileNode(node, indentationLevel);
                }
                else if (element is DotSubGraph subSubGraph)
                {
                    CompileSubGraph(subSubGraph, indentationLevel);
                }
                else if (element is DotString stringElement)
                {
                    CompileStringElement(stringElement, indentationLevel);
                }
                else
                {
                    throw new DotException($"Subgraph body can't contain element of type: {element.GetType()}");
                }
            }

            indentationLevel--;

            _writer.AddIndentation(Indented, indentationLevel);

            _writer.Write("} ");

            _writer.AddIndentationNewLine(Indented);
        }

        private void CompileSubGraphAttributes(IReadOnlyDictionary<string, IDotAttribute> attributes, int indentationLevel)
        {
            if (attributes.Count == 0)
                return;

            foreach (var attribute in attributes)
            {
                var value = attribute.Value.ToString();

                if (FormatStrings && attribute.Value is IFormatStringValue)
                    value = FormatString(value);

                if (attribute.Value is ISurroundWithQuotes)
                    value = SurroundStringWithQuotes(value);
                
                var line = $"{attribute.Key}={value}";

                if (!(attribute.Value is DotCustomAttribute))
                    line += ";";

                CompileLine(line, indentationLevel);
            }
        }

        private void CompileEdge(DotEdge edge, int indentationLevel)
        {
            _writer.AddIndentation(Indented, indentationLevel);

            CompileEdgeEndPoint(edge.Left);

            _writer.Write(_graph.Directed ? " -> " : " -- ");

            CompileEdgeEndPoint(edge.Right);

            CompileAttributes(edge.Attributes);

            _writer.Write("; ");

            _writer.AddIndentationNewLine(Indented);
        }

        private void CompileEdgeEndPoint(IDotElement endPoint)
        {
            if (endPoint is DotString leftEdgeString)
            {
                _writer.Write(SurroundStringWithQuotes(FormatStrings ? FormatString(leftEdgeString.Value) : leftEdgeString.Value));
            }
            else if (endPoint is DotNode leftEdgeNode)
            {
                _writer.Write(SurroundStringWithQuotes(FormatStrings ? FormatString(leftEdgeNode.Identifier) : leftEdgeNode.Identifier));
            }
            else
            {
                throw new DotException($"Endpoint of an edge can't be of type: {endPoint.GetType()}");
            }
        }

        private void CompileNode(DotNode node, int indentationLevel)
        {
            _writer.AddIndentation(Indented, indentationLevel);

            _writer.Write(SurroundStringWithQuotes(FormatStrings ? FormatString(node.Identifier) : node.Identifier));

            CompileAttributes(node.Attributes);

            _writer.Write("; ");

            _writer.AddIndentationNewLine(Indented);
        }

        private void CompileAttributes(IReadOnlyDictionary<string, IDotAttribute> attributes)
        {
            if (attributes.Count == 0)
                return;

            _writer.Write("[");

            var attributeValues = new List<string>();

            foreach (var attribute in attributes)
            {
                var value = attribute.Value.ToString();

                if (FormatStrings && attribute.Value is IFormatStringValue)
                    value = FormatString(value);

                if (attribute.Value is ISurroundWithQuotes)
                    value = SurroundStringWithQuotes(value);
                
                attributeValues.Add($"{attribute.Key}={value}");
            }

            _writer.Write(string.Join(",", attributeValues));

            _writer.Write("]");
        }

        private void CompileStringElement(DotString stringElement, int indentationLevel)
        {
            CompileLine(stringElement.Value, indentationLevel);
        }

        private void CompileLine(string value, int indentationLevel)
        {
            _writer.AddIndentation(Indented, indentationLevel);
            _writer.Write(value + " ");
            _writer.AddIndentationNewLine(Indented);
        }

        internal static string SurroundStringWithQuotes(string value)
        {
            return ValidIdentifierPattern.IsMatch(value) ? value : $"\"{value}\"";
        }

        internal static string FormatString(string value)
        {
            return value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r\n", "\\n")
                .Replace("\n", "\\n");
        }
    }
}