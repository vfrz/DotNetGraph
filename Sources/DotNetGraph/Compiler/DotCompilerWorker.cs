using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public DotCompilerWorker(DotGraph graph,
            TextWriter writer,
            bool indented,
            bool formatStrings,
            bool disposeWriter = false)
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
            {
                _writer?.Dispose();
            }
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

            _writer.Write($"{SurroundStringWithQuotes(_graph.Identifier, FormatStrings)} {{ ");

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

            _writer.Write($"subgraph {SurroundStringWithQuotes(subGraph.Identifier, FormatStrings)} {{ ");

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

        private void CompileSubGraphAttributes(IReadOnlyList<IDotAttribute> attributes, int indentationLevel)
        {
            if (attributes.Count == 0)
                return;

            foreach (var attribute in attributes)
            {
                string line;
                if (attribute is DotSubGraphStyleAttribute subGraphStyleAttribute)
                {
                    line = $"style={SurroundStringWithQuotes(subGraphStyleAttribute.Style.FlagsToString(), FormatStrings)};";
                }
                else if (attribute is DotColorAttribute colorAttribute)
                {
                    line = $"color=\"{colorAttribute.ToHex()}\";";
                }
                else if (attribute is DotLabelAttribute labelAttribute)
                {
                    if (labelAttribute.IsHtml) {
                        line = $"label={labelAttribute.Text};";
                    }
                    else {
                        line = $"label={SurroundStringWithQuotes(labelAttribute.Text, FormatStrings)};";
                    }
                }
                else if (attribute is DotCustomAttribute customAttribute)
                {
                    line = customAttribute.ToString();
                }
                else
                {
                    throw new DotException($"Attribute type not supported: {attribute.GetType()}");
                }

                CompileLine(line, indentationLevel);
            }
        }

        private void CompileEdge(DotEdge edge, int indentationLevel)
        {
            _writer.AddIndentation(Indented, indentationLevel);

            CompileEdgeEndPoint(edge.Left, edge.LeftPort);

            _writer.Write(_graph.Directed ? " -> " : " -- ");

            CompileEdgeEndPoint(edge.Right, edge.RightPort);

            CompileAttributes(edge.Attributes);

            _writer.Write("; ");

            _writer.AddIndentationNewLine(Indented);
        }

        private void CompileEdgeEndPoint(IDotElement endPoint, DotString port=null)
        {
            if (endPoint is DotString leftEdgeString)
            {
                _writer.Write(SurroundStringWithQuotes(leftEdgeString.Value, FormatStrings));
                
            }
            else if (endPoint is DotNode leftEdgeNode)
            {
                _writer.Write(SurroundStringWithQuotes(leftEdgeNode.Identifier, FormatStrings));
            }
            else
            {
                throw new DotException($"Endpoint of an edge can't be of type: {endPoint.GetType()}");
            }
            if (port!=null) {
                _writer.Write(":");
                _writer.Write(SurroundStringWithQuotes(port.Value, FormatStrings));
            }
        }

        private void CompileNode(DotNode node, int indentationLevel)
        {
            _writer.AddIndentation(Indented, indentationLevel);

            _writer.Write(SurroundStringWithQuotes(node.Identifier, FormatStrings));

            CompileAttributes(node.Attributes);

            _writer.Write("; ");

            _writer.AddIndentationNewLine(Indented);
        }

        private void CompileAttributes(IReadOnlyList<IDotAttribute> attributes)
        {
            if (attributes.Count == 0)
                return;

            _writer.Write("[");

            var attributeValues = new List<string>();

            foreach (var attribute in attributes)
            {
                if (attribute is DotNodeShapeAttribute nodeShapeAttribute)
                {
                    attributeValues.Add($"shape={nodeShapeAttribute.Shape.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotNodeStyleAttribute nodeStyleAttribute)
                {
                    attributeValues.Add($"style={SurroundStringWithQuotes(nodeStyleAttribute.Style.FlagsToString(), FormatStrings)}");
                }
                else if (attribute is DotEdgeStyleAttribute edgeStyleAttribute)
                {
                    attributeValues.Add($"style={SurroundStringWithQuotes(edgeStyleAttribute.Style.FlagsToString(), FormatStrings)}");
                }
                else if (attribute is DotFontColorAttribute fontColorAttribute)
                {
                    attributeValues.Add($"fontcolor=\"{fontColorAttribute.ToHex()}\"");
                }
                else if (attribute is DotFillColorAttribute fillColorAttribute)
                {
                    attributeValues.Add($"fillcolor=\"{fillColorAttribute.ToHex()}\"");
                }
                else if (attribute is DotColorAttribute colorAttribute)
                {
                    attributeValues.Add($"color=\"{colorAttribute.ToHex()}\"");
                }
                else if (attribute is DotLabelAttribute labelAttribute)
                {
                    if (labelAttribute.IsHtml) {
                        attributeValues.Add($"label={labelAttribute.Text}");
                    }
                    else {
                        attributeValues.Add($"label={SurroundStringWithQuotes(labelAttribute.Text, FormatStrings)}");
                    }
                }
                else if (attribute is DotNodeWidthAttribute nodeWidthAttribute)
                {
                    attributeValues.Add(string.Format(CultureInfo.InvariantCulture, "width={0:F2}", nodeWidthAttribute.Value));
                }
                else if (attribute is DotNodeHeightAttribute nodeHeightAttribute)
                {
                    attributeValues.Add(string.Format(CultureInfo.InvariantCulture, "height={0:F2}", nodeHeightAttribute.Value));
                }
                else if (attribute is DotPenWidthAttribute dotPenwidthAttribute)
                {
                    attributeValues.Add(string.Format(CultureInfo.InvariantCulture, "penwidth={0:F2}", dotPenwidthAttribute.Value));
                }
                else if (attribute is DotEdgeArrowTailAttribute edgeArrowTailAttribute)
                {
                    attributeValues.Add($"arrowtail={edgeArrowTailAttribute.ArrowType.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotEdgeArrowHeadAttribute edgeArrowHeadAttribute)
                {
                    attributeValues.Add($"arrowhead={edgeArrowHeadAttribute.ArrowType.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotPositionAttribute positionAttribute && positionAttribute.Position != null)
                {
                    attributeValues.Add($"pos=\"{positionAttribute.Position.X},{positionAttribute.Position.Y}!\"");
                }
                else if (attribute is DotCustomAttribute customAttribute)
                {
                    attributeValues.Add(customAttribute.ToString());
                }
                else
                {
                    throw new DotException($"Attribute type not supported: {attribute.GetType()}");
                }
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

        internal static string SurroundStringWithQuotes(string value, bool format)
        {
            var formatted = FormatString(value, format);
            return ValidIdentifierPattern.IsMatch(value) ? formatted : "\"" + formatted + "\"";
        }

        internal static string FormatString(string value, bool format)
        {
            if (!format)
                return value;

            return value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r\n", "\\n")
                .Replace("\n", "\\n");
        }
    }
}
