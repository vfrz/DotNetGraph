using System.Drawing;
using DotNetGraph.Attributes;
using DotNetGraph.Core;
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

            var compiled = graph.CompileToString();

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

            var compiled = graph.CompileToString();

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

            var compiled = graph.CompileToString();

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

            var compiled = graph.CompileToString();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { style=dashed; } }");
        }

        [Fact]
        public void SubGraphWithMultipleStyles()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Style = DotSubGraphStyle.Rounded | DotSubGraphStyle.Filled
                    }
                }
            };

            var compiled = graph.CompileToString();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { style=\"rounded,filled\"; } }");
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

            var compiled = graph.CompileToString();

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

            var compiled = graph.CompileToString();

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

            var compiled = graph.CompileToString();

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

            var compiled = graph.CompileToString();

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

            var compiled = graph.CompileToString();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { TestNode; } }");
        }

        [Fact]
        public void DotSubGraph_WhenRawLineAdded_ThenItsCompiled()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotSubGraph("TestSubGraph")
                    {
                        Elements =
                        {
                            new DotString("{rank = same; A; X;}")
                        }
                    }
                }
            };

            var compiled = graph.CompileToString();

            Check.That(compiled).HasSameValueAs("graph TestGraph { subgraph TestSubGraph { {rank = same; A; X;} } }");
        }

        [Theory]
        [InlineData("rank")]
        [InlineData("Rank")]
        [InlineData("RANK")]
        public void DotSubGraph_WhenCustomAttributeSet_ThenItsCompiled(string rankName)
        {
            var graph = new DotGraph("TestGraph")
                .AddSubGraph("TestSubGraph", subGraph =>
                {
                    subGraph.SetAttribute(rankName, new DotCustomAttribute("same; A; X;"));
                });

            var compiled = graph.CompileToString();

            Check.That(compiled).HasSameValueAs($"graph TestGraph {{ subgraph TestSubGraph {{ {rankName}=same; A; X; }} }}");
        }
    }
}