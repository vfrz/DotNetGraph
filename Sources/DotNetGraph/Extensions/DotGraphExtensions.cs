using DotNetGraph.Compiler;
using DotNetGraph.Core;
using DotNetGraph.Edge;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;
using System;
using System.IO;

namespace DotNetGraph.Extensions
{
    public static class DotGraphExtensions
    {
        public static string Compile(this DotGraph graph, bool indented = false, bool formatStrings = true)
        {
            return new DotCompiler(graph).Compile(indented, formatStrings);
        }

        public static void Compile(this DotGraph graph, Stream stream, bool indented = false, bool formatStrings = true)
        {
            new DotCompiler(graph).Compile(stream, indented, formatStrings);
        }

        public static void Compile(this DotGraph graph, TextWriter writer, bool indented = false, bool formatStrings = true)
        {
            new DotCompiler(graph).Compile(writer, indented, formatStrings);
        }

        public static DotNode NewNode(this IDotGraph graph, string identifier)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            var node = new DotNode(identifier);
            graph.Elements.Add(node);
            return node;
        }

        public static DotEdge NewEdge(this IDotGraph graph, IDotElement left, IDotElement right)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            var edge = new DotEdge(left, right);
            graph.Elements.Add(edge);
            return edge;
        }

        public static DotEdge NewEdge(this IDotGraph graph, string left, string right)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            var edge = new DotEdge(left, right);
            graph.Elements.Add(edge);
            return edge;
        }

        public static DotSubGraph NewSubGraph(this IDotGraph graph, string identifier)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            var subGraph = new DotSubGraph(identifier);
            graph.Elements.Add(subGraph);
            return subGraph;
        }

        public static void AddLine(this IDotGraph graph, string rawLine)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }
            if (string.IsNullOrWhiteSpace(rawLine))
            {
                throw new ArgumentException("Line cannot be empty", nameof(rawLine));
            }

            var stringElement = new DotString(rawLine);
            graph.Elements.Add(stringElement);
        }
    }
}