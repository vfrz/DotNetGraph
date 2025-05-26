using DotNetGraph.Core;
using DotNetGraph.Extensions;
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

        Assert.AreEqual("a", edge.From.Value);
        Assert.IsFalse(edge.From.IsHtml);
    }

    [TestMethod]
    public void FromStringHtml()
    {
        var edge = new DotEdge()
            .From("<b>a</b>", true);

        Assert.AreEqual("<b>a</b>", edge.From.Value);
        Assert.IsTrue(edge.From.IsHtml);
    }

    [TestMethod]
    public void FromNode()
    {
        var node = new DotNode()
            .WithIdentifier("a");

        var edge = new DotEdge()
            .From(node);

        Assert.AreEqual("a", edge.From.Value);
        Assert.IsFalse(edge.From.IsHtml);
    }

    [TestMethod]
    public void FromNodeHtml()
    {
        var node = new DotNode()
            .WithIdentifier("<b>a</b>", true);

        var edge = new DotEdge()
            .From(node);

        Assert.AreEqual("<b>a</b>", edge.From.Value);
        Assert.IsTrue(edge.From.IsHtml);
    }

    [TestMethod]
    public void ToStringDefault()
    {
        var edge = new DotEdge()
            .To("a");

        Assert.AreEqual("a", edge.To.Value);
        Assert.IsFalse(edge.To.IsHtml);
    }

    [TestMethod]
    public void ToStringHtml()
    {
        var edge = new DotEdge()
            .To("<b>a</b>", true);

        Assert.AreEqual("<b>a</b>", edge.To.Value);
        Assert.IsTrue(edge.To.IsHtml);
    }

    [TestMethod]
    public void ToNode()
    {
        var node = new DotNode()
            .WithIdentifier("a");

        var edge = new DotEdge()
            .To(node);

        Assert.AreEqual("a", edge.To.Value);
        Assert.IsFalse(edge.To.IsHtml);
    }

    [TestMethod]
    public void ToNodeHtml()
    {
        var node = new DotNode()
            .WithIdentifier("<b>a</b>", true);

        var edge = new DotEdge()
            .To(node);

        Assert.AreEqual("<b>a</b>", edge.To.Value);
        Assert.IsTrue(edge.To.IsHtml);
    }

    [TestMethod]
    public void WithColorString()
    {
        var edge = new DotEdge()
            .WithColor("red");

        Assert.AreEqual("red", edge.Color.Value);
    }

    [TestMethod]
    public void WithColor()
    {
        var edge = new DotEdge()
            .WithColor(DotColor.Red);

        Assert.AreEqual("#FF0000", edge.Color.Value);
    }

    [TestMethod]
    public void WithStyleString()
    {
        var edge = new DotEdge()
            .WithStyle("custom");

        Assert.AreEqual("custom", edge.Style.Value);
    }

    [TestMethod]
    public void WithStyle()
    {
        var edge = new DotEdge()
            .WithStyle(DotEdgeStyle.Dashed);

        Assert.AreEqual("dashed", edge.Style.Value);
    }

    [TestMethod]
    public void WithPenWidth()
    {
        var edge = new DotEdge()
            .WithPenWidth(123.456);

        Assert.AreEqual(123.456, edge.PenWidth.Value);
    }

    [TestMethod]
    public void WithArrowHeadString()
    {
        var edge = new DotEdge()
            .WithArrowHead("custom");

        Assert.AreEqual("custom", edge.ArrowHead.Value);
    }

    [TestMethod]
    public void WithArrowHead()
    {
        var edge = new DotEdge()
            .WithArrowHead(DotEdgeArrowType.Diamond);

        Assert.AreEqual("diamond", edge.ArrowHead.Value);
    }

    [TestMethod]
    public void WithArrowTailString()
    {
        var edge = new DotEdge()
            .WithArrowTail("custom");

        Assert.AreEqual("custom", edge.ArrowTail.Value);
    }

    [TestMethod]
    public void WithArrowTail()
    {
        var edge = new DotEdge()
            .WithArrowTail(DotEdgeArrowType.Diamond);

        Assert.AreEqual("diamond", edge.ArrowTail.Value);
    }

    [TestMethod]
    public void WithPosString()
    {
        var edge = new DotEdge()
            .WithPos("42,69");

        Assert.AreEqual("42,69", edge.Pos.Value);
    }

    [TestMethod]
    public void WithPos2D()
    {
        var edge = new DotEdge()
            .WithPos(42, 69);

        Assert.AreEqual("42,69", edge.Pos.Value);
    }

    [TestMethod]
    public void WithPos3D()
    {
        var edge = new DotEdge()
            .WithPos(42, 69, 75);

        Assert.AreEqual("42,69,75", edge.Pos.Value);
    }
}