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
    }
}