using System.Drawing;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class DotEdgeExtensionsTests
{
    [TestMethod]
    public void FromStringDefault()
    {
        var edge = new DotEdge()
            .From("a");

        edge.From.Value.Should().Be("a");
        edge.From.IsHtml.Should().Be(false);
    }

    [TestMethod]
    public void FromStringHtml()
    {
        var edge = new DotEdge()
            .From("<b>a</b>", true);

        edge.From.Value.Should().Be("<b>a</b>");
        edge.From.IsHtml.Should().Be(true);
    }

    [TestMethod]
    public void FromNode()
    {
        var node = new DotNode()
            .WithIdentifier("a");

        var edge = new DotEdge()
            .From(node);

        edge.From.Value.Should().Be("a");
        edge.From.IsHtml.Should().Be(false);
    }

    [TestMethod]
    public void FromNodeHtml()
    {
        var node = new DotNode()
            .WithIdentifier("<b>a</b>", true);

        var edge = new DotEdge()
            .From(node);

        edge.From.Value.Should().Be("<b>a</b>");
        edge.From.IsHtml.Should().Be(true);
    }

    [TestMethod]
    public void ToStringDefault()
    {
        var edge = new DotEdge()
            .To("a");

        edge.To.Value.Should().Be("a");
        edge.To.IsHtml.Should().Be(false);
    }

    [TestMethod]
    public void ToStringHtml()
    {
        var edge = new DotEdge()
            .To("<b>a</b>", true);

        edge.To.Value.Should().Be("<b>a</b>");
        edge.To.IsHtml.Should().Be(true);
    }

    [TestMethod]
    public void ToNode()
    {
        var node = new DotNode()
            .WithIdentifier("a");

        var edge = new DotEdge()
            .To(node);

        edge.To.Value.Should().Be("a");
        edge.To.IsHtml.Should().Be(false);
    }

    [TestMethod]
    public void ToNodeHtml()
    {
        var node = new DotNode()
            .WithIdentifier("<b>a</b>", true);

        var edge = new DotEdge()
            .To(node);

        edge.To.Value.Should().Be("<b>a</b>");
        edge.To.IsHtml.Should().Be(true);
    }

    [TestMethod]
    public void WithColorString()
    {
        var edge = new DotEdge()
            .WithColor("red");

        edge.Color.Value.Should().Be("red");
    }

    [TestMethod]
    public void WithColor()
    {
        var edge = new DotEdge()
            .WithColor(Color.Red);

        edge.Color.Value.Should().Be("#FF0000");
    }

    [TestMethod]
    public void WithStyleString()
    {
        var edge = new DotEdge()
            .WithStyle("custom");

        edge.Style.Value.Should().Be("custom");
    }

    [TestMethod]
    public void WithStyle()
    {
        var edge = new DotEdge()
            .WithStyle(DotEdgeStyle.Dashed);

        edge.Style.Value.Should().Be("dashed");
    }

    [TestMethod]
    public void WithPenWidth()
    {
        var edge = new DotEdge()
            .WithPenWidth(123.456);

        edge.PenWidth.Value.Should().Be(123.456);
    }

    [TestMethod]
    public void WithArrowHeadString()
    {
        var edge = new DotEdge()
            .WithArrowHead("custom");

        edge.ArrowHead.Value.Should().Be("custom");
    }

    [TestMethod]
    public void WithArrowHead()
    {
        var edge = new DotEdge()
            .WithArrowHead(DotEdgeArrowType.Diamond);

        edge.ArrowHead.Value.Should().Be("diamond");
    }

    [TestMethod]
    public void WithArrowTailString()
    {
        var edge = new DotEdge()
            .WithArrowTail("custom");

        edge.ArrowTail.Value.Should().Be("custom");
    }

    [TestMethod]
    public void WithArrowTail()
    {
        var edge = new DotEdge()
            .WithArrowTail(DotEdgeArrowType.Diamond);

        edge.ArrowTail.Value.Should().Be("diamond");
    }

    [TestMethod]
    public void WithPosString()
    {
        var edge = new DotEdge()
            .WithPos("42,69");

        edge.Pos.Value.Should().Be("42,69");
    }

    [TestMethod]
    public void WithPos2D()
    {
        var edge = new DotEdge()
            .WithPos(42, 69);

        edge.Pos.Value.Should().Be("42,69");
    }

    [TestMethod]
    public void WithPos3D()
    {
        var edge = new DotEdge()
            .WithPos(42, 69, 75);

        edge.Pos.Value.Should().Be("42,69,75");
    }
}