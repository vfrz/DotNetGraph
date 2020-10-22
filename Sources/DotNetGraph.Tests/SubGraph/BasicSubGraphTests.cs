using System;
using System.Drawing;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests.SubGraph
{
    public class BasicSubGraphTests
    {
        [Fact]
        public void EmptySubGraph()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { } }");
        }

        [Fact]
        public void SubGraphWithSpaceInIdentifier()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("My test subgraph")
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph \"My test subgraph\" { } }");
        }

        [Fact]
        public void SubGraphWithMultipleAttributes()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Style = DotSubGraphStyle.Dashed,
                        Color = Color.Red,
                        Label = "Hello, world!"
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { style=dashed; color=\"#FF0000\"; label=\"Hello, world!\"; } }");
        }

        [Fact]
        public void SubGraphWithStyle()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Style = DotSubGraphStyle.Dashed
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { style=dashed; } }");
        }

        [Fact]
        public void SubGraphWithLabel()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Label = "Hello, \"world\"!"
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { label=\"Hello, \\\"world\\\"!\"; } }");
        }

        [Fact]
        public void SubGraphWithColor()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Color = Color.Red
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { color=\"#FF0000\"; } }");
        }

        [Fact]
        public void SubGraphWithEdge()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Elements =
                        {
                            new DotEdge("hello", "world")
                        }
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { hello -- world; } }");
        }

        [Fact]
        public void SubGraphWithEdgeDirected()
        {
            var graph = new DotGraph("TestGraph")
            {
                Directed = true,
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Elements =
                        {
                            new DotEdge("hello", "world")
                        }
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("digraph TestGraph { subgraph TestSubGraph { hello -> world; } }");
        }

        [Fact]
        public void SubGraphWithNode()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Elements =
                        {
                            new DotNode("TestNode")
                        }
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { TestNode; } }");
        }

        [Fact]
        public void EdgeWithNullNodesThrowsException()
        {
            var node = new DotNode("example");

            Check.ThatCode(() => new DotEdge(null, node)).Throws<ArgumentNullException>();
            Check.ThatCode(() => new DotEdge(node, null)).Throws<ArgumentNullException>();

            Check.ThatCode(() => new DotEdge(null, "test")).Throws<ArgumentNullException>();
            Check.ThatCode(() => new DotEdge("test", null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void EdgeWithEmptyNodeIdentifierThrowsException()
        {
            Check.ThatCode(() => new DotEdge(string.Empty, "test")).Throws<ArgumentException>();
            Check.ThatCode(() => new DotEdge(" ", "test")).Throws<ArgumentException>();
            Check.ThatCode(() => new DotEdge("test", string.Empty)).Throws<ArgumentException>();
            Check.ThatCode(() => new DotEdge("test", " ")).Throws<ArgumentException>();
        }
    }
}