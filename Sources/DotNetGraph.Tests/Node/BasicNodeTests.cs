using System.Drawing;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests.Node
{
    public class BasicNodeTests
    {
        [Fact]
        public void EmptyNode()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode ; }");
        }

        [Fact]
        public void NodeWithMultipleAttributes()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Color = Color.Blue,
                        Label = "Test",
                        Shape = DotNodeShape.Box
                    }
                }
            };
            
            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [color=\"#0000FF\",label=\"Test\",shape=box]; }");
        }

        [Fact]
        public void NodeWithColor()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode", Color.Red)
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [color=\"#FF0000\"]; }");
        }

        [Fact]
        public void NodeWithShape()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Shape = DotNodeShape.Square
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [shape=square]; }");
        }

        [Fact]
        public void NodeWithStyle()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Style = DotNodeStyle.Dashed
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [style=dashed]; }");
        }

        [Fact]
        public void NodeWithFontColor()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        FontColor = Color.Red
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [fontcolor=\"#FF0000\"]; }");
        }

        [Fact]
        public void NodeWithFillColor()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        FillColor = Color.Red
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [fillcolor=\"#FF0000\"]; }");
        }

        [Fact]
        public void NodeWithLabel()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Label = "Hello, \"world\"!"
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [label=\"Hello, \\\"world\\\"!\"]; }");
        }
    }
}