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
        public static string CompileToString(this DotGraph graph, bool indented = false, bool formatStrings = true)
        {
            return new DotCompiler(graph).CompileToString(indented, formatStrings);
        }

        public static void CompileToStream(this DotGraph graph, Stream stream, bool indented = false, bool formatStrings = true)
        {
            new DotCompiler(graph).CompileToStream(stream, indented, formatStrings);
        }

        public static void CompileToTextWriter(this DotGraph graph, TextWriter writer, bool indented = false, bool formatStrings = true)
        {
            new DotCompiler(graph).CompileToTextWriter(writer, indented, formatStrings);
        }

        public static T AddNode<T>(this T graph, string identifier, Action<DotNode> nodeSetup = null) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            var node = new DotNode(identifier);
            graph.Elements.Add(node);

            nodeSetup?.Invoke(node);
            return graph;
        }

        public static T AddNode<T>(this T graph, DotNode node) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            if (node is null)
                throw new ArgumentNullException(nameof(node));

            graph.Elements.Add(node);
            return graph;
        }

        public static T AddEdge<T>(this T graph, IDotElement left, IDotElement right, Action<DotEdge> edgeSetup = null) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            var edge = new DotEdge(left, right);
            graph.Elements.Add(edge);

            edgeSetup?.Invoke(edge);
            return graph;
        }

        public static T AddEdge<T>(this T graph, string left, string right, Action<DotEdge> edgeSetup = null) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            var edge = new DotEdge(left, right);
            graph.Elements.Add(edge);

            edgeSetup?.Invoke(edge);
            return graph;
        }

        public static T AddEdge<T>(this T graph, DotEdge edge) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            if (edge is null)
                throw new ArgumentNullException(nameof(edge));

            graph.Elements.Add(edge);
            return graph;
        }

        public static T AddSubGraph<T>(this T graph, string identifier, Action<DotSubGraph> subGraphSetup = null) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            var subGraph = new DotSubGraph(identifier);
            graph.Elements.Add(subGraph);

            subGraphSetup?.Invoke(subGraph);
            return graph;
        }

        public static T AddSubGraph<T>(this T graph, DotSubGraph subGraph) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            if (subGraph is null)
                throw new ArgumentNullException(nameof(subGraph));

            graph.Elements.Add(subGraph);
            return graph;
        }

        public static T AddRawLine<T>(this T graph, string rawLine) where T : IDotGraph
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));

            if (string.IsNullOrWhiteSpace(rawLine))
                throw new ArgumentException("Line cannot be null or empty", nameof(rawLine));

            var stringElement = new DotString(rawLine);
            graph.Elements.Add(stringElement);

            return graph;
        }
    }
}