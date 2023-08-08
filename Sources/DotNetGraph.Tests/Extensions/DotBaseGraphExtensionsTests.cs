using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
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

        graph.Identifier.Value.Should().Be("Test");
        graph.Identifier.IsHtml.Should().Be(false);
    }

    [TestMethod]
    public void WithIdentifierHtml()
    {
        var graph = new DotGraph()
            .WithIdentifier("<b>Test</b>", true);

        graph.Identifier.Value.Should().Be("<b>Test</b>");
        graph.Identifier.IsHtml.Should().Be(true);
    }

    [TestMethod]
    public void WithRankDir()
    {
        var graph = new DotGraph()
            .WithRankDir(DotRankDir.TB);

        graph.RankDir.Should().Be(DotRankDir.TB);
    }

    [TestMethod]
    public void Add()
    {
        var node = new DotNode();

        var graph = new DotGraph()
            .Add(node);

        graph.Elements.Should().Contain(node);
    }
}