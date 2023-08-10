using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class DotSubgraphExtensionsTests
{
    [TestMethod]
    public void WithColorString()
    {
        var subgraph = new DotSubgraph()
            .WithColor("red");

        subgraph.Color.Value.Should().Be("red");
    }

    [TestMethod]
    public void WithColor()
    {
        var subgraph = new DotSubgraph()
            .WithColor(DotColor.Red);

        subgraph.Color.Value.Should().Be("#FF0000");
    }


    [TestMethod]
    public void WithStyleString()
    {
        var subgraph = new DotSubgraph()
            .WithStyle("custom");

        subgraph.Style.Value.Should().Be("custom");
    }

    [TestMethod]
    public void WithStyle()
    {
        var subgraph = new DotSubgraph()
            .WithStyle(DotSubgraphStyle.Striped);

        subgraph.Style.Value.Should().Be("striped");
    }
}