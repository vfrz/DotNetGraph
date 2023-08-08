using System.Drawing;
using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class DotElementExtensionsTests
{
    [TestMethod]
    public void WithLabel()
    {
        var node = new DotNode()
            .WithLabel("Test");

        node.Label.Value.Should().Be("Test");
        node.Label.IsHtml.Should().Be(false);
    }

    [TestMethod]
    public void WithAttributeString()
    {
        var node = new DotNode()
            .WithAttribute("hello", "world");

        var attribute = node.GetAttribute("hello") as DotAttribute;
        attribute?.Value.Should().Be("world");
    }

    [TestMethod]
    public void WithAttribute()
    {
        var node = new DotNode()
            .WithAttribute("hello", new DotAttribute("world"));

        var attribute = node.GetAttribute("hello") as DotAttribute;
        attribute?.Value.Should().Be("world");
    }

    [TestMethod]
    public void WithFontColorString()
    {
        var node = new DotNode()
            .WithFontColor("red");

        node.FontColor.Value.Should().Be("red");
    }

    [TestMethod]
    public void WithFontColor()
    {
        var node = new DotNode()
            .WithFontColor(Color.Red);

        node.FontColor.Value.Should().Be("#FF0000");
    }
}