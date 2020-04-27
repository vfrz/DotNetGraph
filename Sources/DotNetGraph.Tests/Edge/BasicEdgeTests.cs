using System.Drawing;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests.Edge
{
    public class BasicEdgeTests
    {
        [Fact]
        public void EdgeWithIdentifierToIdentifier()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"; }");
        }

        [Fact]
        public void EdgeWithIdentifierToIdentifierDirectedGraph()
        {
            var graph = new DotGraph("TestGraph")
            {
                Directed = true,
                Elements =
                {
                    new DotEdge("hello", "world")
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("digraph \"TestGraph\" { \"hello\" -> \"world\"; }");
        }

        [Fact]
        public void EdgeWithNodeToNode()
        {
            var helloNode = new DotNode("hello");

            var worldNode = new DotNode("world");

            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    helloNode,
                    worldNode,
                    new DotEdge(helloNode, worldNode)
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\"; \"world\"; \"hello\" -- \"world\"; }");
        }

        [Fact]
        public void EdgeWithMultipleAttributes()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        Color = Color.Red,
                        ArrowHead = DotEdgeArrowType.Box,
                        ArrowTail = DotEdgeArrowType.Diamond
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"[color=\"#FF0000\",arrowhead=box,arrowtail=diamond]; }");
        }

        [Fact]
        public void EdgeWithColor()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        Color = Color.Red
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"[color=\"#FF0000\"]; }");
        }

        [Fact]
        public void EdgeWithFontColor()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        FontColor = Color.Blue
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"[fontcolor=\"#0000FF\"]; }");
        }

        [Fact]
        public void EdgeWithLabel()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        Label = "Hello, \"world\"!"
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"[label=\"Hello, \\\"world\\\"!\"]; }");
        }

        [Fact]
        public void EdgeWithStyle()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        Style = DotEdgeStyle.Dashed
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"[style=dashed]; }");
        }

        [Fact]
        public void EdgeWithArrowHead()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        ArrowHead = DotEdgeArrowType.Box
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"[arrowhead=box]; }");
        }

        [Fact]
        public void EdgeWithArrowTail()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        ArrowTail = DotEdgeArrowType.Diamond
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph \"TestGraph\" { \"hello\" -- \"world\"[arrowtail=diamond]; }");
        }
    }
}