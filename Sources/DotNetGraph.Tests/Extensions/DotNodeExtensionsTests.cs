using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class DotNodeExtensionsTests
{
    [TestMethod]
    public void WithIdentifier()
    {
        var node = new DotNode()
            .WithIdentifier("Test");

        Assert.AreEqual("Test", node.Identifier.Value);
        Assert.IsFalse(node.Identifier.IsHtml);
    }

    [TestMethod]
    public void WithIdentifierHtml()
    {
        var node = new DotNode()
            .WithIdentifier("<b>Test</b>", true);

        Assert.AreEqual("<b>Test</b>", node.Identifier.Value);
        Assert.IsTrue(node.Identifier.IsHtml);
    }

    [TestMethod]
    public void WithColorString()
    {
        var node = new DotNode()
            .WithColor("red");

        Assert.AreEqual("red", node.Color.Value);
    }

    [TestMethod]
    public void WithColor()
    {
        var node = new DotNode()
            .WithColor(DotColor.Red);

        Assert.AreEqual("#FF0000", node.Color.Value);
    }

    [TestMethod]
    public void WithFillColorString()
    {
        var node = new DotNode()
            .WithFillColor("red");

        Assert.AreEqual("red", node.FillColor.Value);
    }

    [TestMethod]
    public void WithFillColor()
    {
        var node = new DotNode()
            .WithFillColor(DotColor.Red);

        Assert.AreEqual("#FF0000", node.FillColor.Value);
    }

    [TestMethod]
    public void WithShapeString()
    {
        var node = new DotNode()
            .WithShape("custom");

        Assert.AreEqual("custom", node.Shape.Value);
    }

    [TestMethod]
    public void WithShape()
    {
        var node = new DotNode()
            .WithShape(DotNodeShape.Diamond);

        Assert.AreEqual("diamond", node.Shape.Value);
    }

    [TestMethod]
    public void WithStyleString()
    {
        var node = new DotNode()
            .WithStyle("custom");

        Assert.AreEqual("custom", node.Style.Value);
    }

    [TestMethod]
    public void WithStyle()
    {
        var node = new DotNode()
            .WithStyle(DotNodeStyle.Diagonals);

        Assert.AreEqual("diagonals", node.Style.Value);
    }

    [TestMethod]
    public void WithWidth()
    {
        var node = new DotNode()
            .WithWidth(123.456);

        Assert.AreEqual(123.456, node.Width.Value);
    }

    [TestMethod]
    public void WithHeight()
    {
        var node = new DotNode()
            .WithHeight(123.456);

        Assert.AreEqual(123.456, node.Height.Value);
    }

    [TestMethod]
    public void WithPenWidth()
    {
        var node = new DotNode()
            .WithPenWidth(123.456);

        Assert.AreEqual(123.456, node.PenWidth.Value);
    }

    [TestMethod]
    public void WithPosString()
    {
        var node = new DotNode()
            .WithPos("42,69");

        Assert.AreEqual("42,69", node.Pos.Value);
    }

    [TestMethod]
    public void WithPos2D()
    {
        var node = new DotNode()
            .WithPos(42, 69);

        Assert.AreEqual("42,69", node.Pos.Value);
    }

    [TestMethod]
    public void WithPos3D()
    {
        var node = new DotNode()
            .WithPos(42, 69, 75);

        Assert.AreEqual("42,69,75", node.Pos.Value);
    }
}