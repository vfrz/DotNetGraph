using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class DotBaseGraphExtensionsTests
{
    [TestMethod]
    public void WithIdentifier()
    {
        var graph = new DotGraph()
            .WithIdentifier("Test");

        Assert.AreEqual("Test", graph.Identifier.Value);
        Assert.IsFalse(graph.Identifier.IsHtml);
    }

    [TestMethod]
    public void WithIdentifierHtml()
    {
        var graph = new DotGraph()
            .WithIdentifier("<b>Test</b>", true);

        Assert.AreEqual("<b>Test</b>", graph.Identifier.Value);
        Assert.IsTrue(graph.Identifier.IsHtml);
    }

    [TestMethod]
    public void WithRankDir()
    {
        var graph = new DotGraph()
            .WithRankDir(DotRankDir.TB);

        Assert.AreEqual("TB", graph.RankDir.Value);
    }

    [TestMethod]
    public void Add()
    {
        var node = new DotNode();

        var graph = new DotGraph()
            .Add(node);

        Assert.Contains(node, graph.Elements);
    }
}