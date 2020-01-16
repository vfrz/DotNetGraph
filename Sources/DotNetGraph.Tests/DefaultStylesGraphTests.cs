using System.Drawing;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests
{
    public class DefaultStylesGraphTests
    {
        [Fact]
        public void NullNodeDefaultStyle()
        {
            var graph = new DotGraph("TestGraph")
                .WithDefaultNodeStyleLayout(null)
                .AddNode("TestNode");

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode ; }");
        }

        [Fact]
        public void DefaultColorNodeDefaultStyle()
        {
            var graph = new DotGraph("TestGraph")
                .WithDefaultNodeStyleLayout(new DotNodeStyleLayout
                {
                    Color = Color.Red
                })
                .AddNode("TestNode");

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [color=\"#FF0000\"]; }");
        }

        [Fact]
        public void CompleteNodeDefaultStyle()
        {
            var graph = new DotGraph("TestGraph")
                .WithDefaultNodeStyleLayout(new DotNodeStyleLayout
                {
                    Color = Color.Red,
                    Height = 0.64f,
                    Shape = DotNodeShape.Box,
                    Style = DotNodeStyle.Dashed,
                    FillColor = Color.Blue,
                    FontColor = Color.Yellow
                })
                .AddNode("TestNode");

            var compiled = graph.Compile();

            Check.That(compiled).HasSameValueAs("graph TestGraph { TestNode [color=\"#FF0000\",height=0.64,shape=box,style=dashed,fillcolor=\"#0000FF\",fontcolor=\"#FFFF00\"]; }");
        }
    }
}