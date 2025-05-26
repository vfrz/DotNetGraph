using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
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

        Assert.AreEqual("Test", node.Label.Value);
        Assert.IsFalse(node.Label.IsHtml);
    }

    [TestMethod]
    public void WithAttributeString()
    {
        var node = new DotNode()
            .WithAttribute("hello", "world");

        var attribute = node.GetAttribute("hello") as DotAttribute;
        Assert.AreEqual("world", attribute?.Value);
    }

    [TestMethod]
    public void WithAttribute()
    {
        var node = new DotNode()
            .WithAttribute("hello", new DotAttribute("world"));

        var attribute = node.GetAttribute("hello") as DotAttribute;
        Assert.AreEqual("world", attribute?.Value);
    }

    [TestMethod]
    public void WithFontColorString()
    {
        var node = new DotNode()
            .WithFontColor("red");

        Assert.AreEqual("red", node.FontColor.Value);
    }

    [TestMethod]
    public void WithFontColor()
    {
        var node = new DotNode()
            .WithFontColor(DotColor.Red);

        Assert.AreEqual("#FF0000", node.FontColor.Value);
    }
}