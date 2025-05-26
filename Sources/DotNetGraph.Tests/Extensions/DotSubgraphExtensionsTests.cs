using DotNetGraph.Core;
using DotNetGraph.Extensions;
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

        Assert.AreEqual("red", subgraph.Color.Value);
    }

    [TestMethod]
    public void WithColor()
    {
        var subgraph = new DotSubgraph()
            .WithColor(DotColor.Red);

        Assert.AreEqual("#FF0000", subgraph.Color.Value);
    }


    [TestMethod]
    public void WithStyleString()
    {
        var subgraph = new DotSubgraph()
            .WithStyle("custom");

        Assert.AreEqual("custom", subgraph.Style.Value);
    }

    [TestMethod]
    public void WithStyle()
    {
        var subgraph = new DotSubgraph()
            .WithStyle(DotSubgraphStyle.Striped);

        Assert.AreEqual("striped", subgraph.Style.Value);
    }
}