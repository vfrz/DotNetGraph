using DotNetGraph.Extensions;
using DotNetGraph.Node;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests
{
    public class BasicGraphTests
    {
        [Fact]
        public void GraphWithSpaceInIdentifier()
        {
            var graph = new DotGraph("My test graph");

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"My test graph\" { }");
        }

        [Fact]
        public void EmptyDirectedGraph()
        {
            var graph = new DotGraph("TestGraph", true);

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("digraph TestGraph { }");
        }

        [Fact]
        public void EmptyGraph()
        {
            var graph = new DotGraph("TestGraph");

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { }");
        }

        [Fact]
        public void EmptyStrictGraph()
        {
            var graph = new DotGraph("TestGraph")
            {
                Strict = true
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("strict graph TestGraph { }");
        }

        [Fact]
        public void GraphWithoutStringsFormat()
        {
            var graph = new DotGraph("TestGraph", true);

            graph.Elements.Add(new DotNode("TestNode")
            {
                Label = "\\lTesting"
            });

            var compiled = graph.Compile(false, false);

            Check.That(compiled).HasSameValueAs("digraph TestGraph { TestNode[label=\"\\lTesting\"]; }");
        }
    }
}