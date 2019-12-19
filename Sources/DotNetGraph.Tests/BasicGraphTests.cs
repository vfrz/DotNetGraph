using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests
{
    public class BasicGraphTests
    {
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
        public void SimpleEdgeGraph()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge
                    {
                        Left = new DotString("hello"),
                        Right = new DotString("world")
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world }");
        }

        [Fact]
        public void SimpleEdgeDirectedGraph()
        {
            var graph = new DotGraph("TestGraph", true)
            {
                Elements =
                {
                    new DotEdge
                    {
                        Left = new DotString("hello"),
                        Right = new DotString("world")
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("digraph TestGraph { hello -> world }");
        }
    }
}