using System.Drawing;
using System.Globalization;
using System.Threading;
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

        [Fact]
        public void NodeWithPenWidth()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        PenWidth = 0.64f
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [penwidth=0.64]; }");
        }

        [Fact]
        public void NodeWithWidth()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Width = 0.64f
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [width=0.64]; }");
        }
        
        [Fact]
        public void NodeWithHeight()
        {
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Height = 0.64f
                    }
                }
            };

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [height=0.64]; }");
        }
        
        [Fact]
        public void NodeWithWidthAndHeightUsesCorrectCulture()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            var currentUiCulture = Thread.CurrentThread.CurrentUICulture;
            
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Width = 0.46f,
                        Height = 0.64f
                    }
                }
            };

            var cultureInfo = new CultureInfo("de-DE");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            
            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [width=0.46,height=0.64]; }");
            
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentUiCulture;
        }
        
        [Fact]
        public void NodeWithLargeHeightUsesCorrectCulture()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            var currentUiCulture = Thread.CurrentThread.CurrentUICulture;
            
            var graph = new DotGraph("TestGraph")
            {
                Elements =
                {
                    new DotNode("TestNode")
                    {
                        Height = 12345.67f
                    }
                }
            };

            var cultureInfo = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            
            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [height=12345.67]; }");
            
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentUiCulture;
        }
    }
}