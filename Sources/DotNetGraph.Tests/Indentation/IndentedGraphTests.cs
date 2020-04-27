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
            
            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \n}");
        }

        [Fact]
        public void BasicIndentedDirectedGraph()
        {
            var graph = new DotGraph("TestGraph", true);

            var compiled = graph.Compile(true);
            
            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("digraph \"TestGraph\" { \n}");
        }

        [Fact]
        public void BasicIndentedEdge()
        {
            var graph = new DotGraph("TestGraph");
            
            graph.Elements.Add(new DotEdge("A", "B"));

            var compiled = graph.Compile(true);
            
            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \n\t\"A\" -- \"B\"; \n}");
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

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \n\t\"A\" -- \"B\"[style=dashed,color=\"#FF0000\"]; \n}");
        }

        [Fact]
        public void BasicIndentedSubGraph()
        {
            var graph = new DotGraph("TestGraph");
            
            graph.Elements.Add(new DotSubGraph("TestSubGraph"));
            
            var compiled = graph.Compile(true);
            
            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \n\tsubgraph \"TestSubGraph\" { \n\t} \n}");
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

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \n\tsubgraph \"TestSubGraph\" { \n\t\t\"A\" -- \"B\"; \n\t} \n}");
        }
        
        [Fact]
        public void BasicIndentedNode()
        {
            var graph = new DotGraph("TestGraph");
            
            graph.Elements.Add(new DotNode("TestNode"));

            var compiled = graph.Compile(true);
            
            _output.WriteLine(compiled);

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \n\t\"TestNode\"; \n}");
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

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \n\t\"TestNode\"[color=\"#FF0000\",style=bold]; \n}");
        }
    }
}