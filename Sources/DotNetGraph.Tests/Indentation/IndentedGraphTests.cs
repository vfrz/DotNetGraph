using System.Drawing;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;
using NFluent;
using Xunit;
using Xunit.Abstractions;

namespace DotNetGraph.Tests.Indentation
{
    public class IndentedGraphTests
    {
        private readonly ITestOutputHelper _output;

        public IndentedGraphTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void BasicIndentedGraph()
        {
            var graph = new DotGraph("TestGraph");

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph TestGraph { \n}");
        }

        [Fact]
        public void BasicIndentedDirectedGraph()
        {
            var graph = new DotGraph("TestGraph", true);

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("digraph TestGraph { \n}");
        }

        [Fact]
        public void BasicIndentedEdge()
        {
            var graph = new DotGraph("TestGraph");

            graph.Elements.Add(new DotEdge("A", "B"));

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph TestGraph { \n\tA -- B; \n}");
        }

        [Fact]
        public void IndentedEdgeWithAttributes()
        {
            var graph = new DotGraph("TestGraph");

            var edge = new DotEdge("A", "B")
            {
                Style = DotEdgeStyle.Dashed,
                Color = Color.Red
            };

            graph.Elements.Add(edge);

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph TestGraph { \n\tA -- B[style=dashed,color=\"#FF0000\"]; \n}");
        }

        [Fact]
        public void BasicIndentedSubGraph()
        {
            var graph = new DotGraph("TestGraph");

            graph.Elements.Add(new DotSubGraph("TestSubGraph"));

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph TestGraph { \n\tsubgraph TestSubGraph { \n\t} \n}");
        }

        [Fact]
        public void IndentedSubGraphWithEdge()
        {
            var graph = new DotGraph("TestGraph");

            var subGraph = new DotSubGraph("TestSubGraph");

            subGraph.Elements.Add(new DotEdge("A", "B"));

            graph.Elements.Add(subGraph);

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph TestGraph { \n\tsubgraph TestSubGraph { \n\t\tA -- B; \n\t} \n}");
        }

        [Fact]
        public void BasicIndentedNode()
        {
            var graph = new DotGraph("TestGraph");

            graph.Elements.Add(new DotNode("TestNode"));

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph TestGraph { \n\tTestNode; \n}");
        }

        [Fact]
        public void IndentedNodeWithAttributes()
        {
            var graph = new DotGraph("TestGraph");

            var edge = new DotNode("TestNode")
            {
                Color = Color.Red,
                Style = DotNodeStyle.Bold
            };

            graph.Elements.Add(edge);

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph TestGraph { \n\tTestNode[color=\"#FF0000\",style=bold]; \n}");
        }

        [Fact]
        public void DotGraph_WhenNodesSubGraphsEdgesAndCustomLinesProvided_ThenCompilationIsFormattedCorrectly()
        {
            var graph = new DotGraph("TestGraph", true);
            graph.AddLine("rankdir = TB;");

            var subGraph = graph.NewSubGraph("cluster_0");
            subGraph.Label = "Test Sub Graph";
            subGraph.NewNode("A");
            subGraph.NewNode("B");
            subGraph.AddLine("{rank = same; A; X;}");

            graph.NewEdge("A", "B");

            var compiled = graph.Compile(true);

            _output.WriteLine(compiled);

            // digraph TestGraph { 
            // 	rankdir = TB; 
            // 	subgraph cluster_0 { 
            // 		label="Test Sub Graph";
            // 		A; 
            // 		B; 
            // 		{rank = same; A; X;} 
            // 	} 
            // 	A -> B; 
            // }

            var expected2 = "digraph TestGraph { \n\trankdir = TB; \n\tsubgraph cluster_0 { \n\t\tlabel=\"Test Sub Graph\"; \n\t\tA; \n\t\tB; \n\t\t{rank = same; A; X;} \n\t} \n\tA -> B; \n}";

            Check.That(compiled).HasSameValueAs(expected2);
        }
    }
}