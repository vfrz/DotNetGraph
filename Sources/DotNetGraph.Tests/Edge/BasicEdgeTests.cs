using System;
using System.Drawing;
using DotNetGraph.Attributes;
using DotNetGraph.Core;
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world; }");
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

            Check.That(compiled).HasSameValueAs("digraph TestGraph { hello -> world; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello; world; hello -- world; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[color=\"#FF0000\",arrowhead=box,arrowtail=diamond]; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[color=\"#FF0000\"]; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[fontcolor=\"#0000FF\"]; }");
        }

        [Fact]
        public void EdgeWithPosition()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        Position = new DotPosition(4, 2)
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[pos=\"4,2!\"]; }");
        }

        [Fact]
        public void EdgeWithPenWidth()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        PenWidth = 0.46f
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[penwidth=0.46]; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[label=\"Hello, \\\"world\\\"!\"]; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[style=dashed]; }");
        }

        [Fact]
        public void EdgeWithMultipleStyles()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotEdge("hello", "world")
                    {
                        Style = DotEdgeStyle.Dashed | DotEdgeStyle.Dotted
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[style=\"dashed,dotted\"]; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[arrowhead=box]; }");
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

            Check.That(compiled).HasSameValueAs("graph TestGraph { hello -- world[arrowtail=diamond]; }");
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

        [Fact]
        public void ModifyEdgeWithNullNodesThrowsException()
        {
            var edge = new DotEdge(new DotNode("left"), new DotNode("right"));

            Check.ThatCode(() => edge.Left = null).Throws<ArgumentNullException>();
            Check.ThatCode(() => edge.Right = null).Throws<ArgumentNullException>();
        }

        [Theory]
        [InlineData("style")]
        [InlineData("Style")]
        [InlineData("STYLE")]
        public void DotEdge_WhenCustomAttributeSet_ThenItsCompiled(string styleName)
        {
            var graph = new DotGraph("TestGraph")
                .AddEdge("hello", "world", edge =>
                {
                    edge.SetAttribute(styleName, new DotCustomAttribute("dashed"));
                });

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs($"graph TestGraph {{ hello -- world[{styleName}=dashed]; }}");
        }
    }
}