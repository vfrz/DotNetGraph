using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
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

        node.Identifier.Value.Should().Be("Test");
        node.Identifier.IsHtml.Should().Be(false);
    }

    [TestMethod]
    public void WithIdentifierHtml()
    {
        var node = new DotNode()
            .WithIdentifier("<b>Test</b>", true);

        node.Identifier.Value.Should().Be("<b>Test</b>");
        node.Identifier.IsHtml.Should().Be(true);
    }

    [TestMethod]
    public void WithColorString()
    {
        var node = new DotNode()
            .WithColor("red");

        node.Color.Value.Should().Be("red");
    }

    [TestMethod]
    public void WithColor()
    {
        var node = new DotNode()
            .WithColor(DotColor.Red);

        node.Color.Value.Should().Be("#FF0000");
    }

    [TestMethod]
    public void WithFillColorString()
    {
        var node = new DotNode()
            .WithFillColor("red");

        node.FillColor.Value.Should().Be("red");
    }

    [TestMethod]
    public void WithFillColor()
    {
        var node = new DotNode()
            .WithFillColor(DotColor.Red);

        node.FillColor.Value.Should().Be("#FF0000");
    }

    [TestMethod]
    public void WithShapeString()
    {
        var node = new DotNode()
            .WithShape("custom");

        node.Shape.Value.Should().Be("custom");
    }

    [TestMethod]
    public void WithShape()
    {
        var node = new DotNode()
            .WithShape(DotNodeShape.Diamond);

        node.Shape.Value.Should().Be("diamond");
    }

    [TestMethod]
    public void WithStyleString()
    {
        var node = new DotNode()
            .WithStyle("custom");

        node.Style.Value.Should().Be("custom");
    }

    [TestMethod]
    public void WithStyle()
    {
        var node = new DotNode()
            .WithStyle(DotNodeStyle.Diagonals);

        node.Style.Value.Should().Be("diagonals");
    }

    [TestMethod]
    public void WithWidth()
    {
        var node = new DotNode()
            .WithWidth(123.456);

        node.Width.Value.Should().Be(123.456);
    }

    [TestMethod]
    public void WithHeight()
    {
        var node = new DotNode()
            .WithHeight(123.456);

        node.Height.Value.Should().Be(123.456);
    }

    [TestMethod]
    public void WithPenWidth()
    {
        var node = new DotNode()
            .WithPenWidth(123.456);

        node.PenWidth.Value.Should().Be(123.456);
    }

    [TestMethod]
    public void WithPosString()
    {
        var node = new DotNode()
            .WithPos("42,69");

        node.Pos.Value.Should().Be("42,69");
    }

    [TestMethod]
    public void WithPos2D()
    {
        var node = new DotNode()
            .WithPos(42, 69);

        node.Pos.Value.Should().Be("42,69");
    }

    [TestMethod]
    public void WithPos3D()
    {
        var node = new DotNode()
            .WithPos(42, 69, 75);

        node.Pos.Value.Should().Be("42,69,75");
    }
}