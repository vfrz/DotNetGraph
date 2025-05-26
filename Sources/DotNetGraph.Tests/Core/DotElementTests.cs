using System;
using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotElementTests
{
    [TestMethod]
    public void HasAttributeTrue()
    {
        var node = new DotNode()
            .WithLabel("Test");

        var hasAttribute = node.HasAttribute("label");

        Assert.IsTrue(hasAttribute);
    }

    [TestMethod]
    public void HasAttributeFalse()
    {
        var node = new DotNode();

        var hasAttribute = node.HasAttribute("label");

        Assert.IsFalse(hasAttribute);
    }

    [TestMethod]
    public void GetAttributeMissing()
    {
        var node = new DotNode();

        Assert.Throws<Exception>(() => node.GetAttribute("label"));
    }

    [TestMethod]
    public void GetAttributeOrDefault()
    {
        var node = new DotNode()
            .WithLabel("Test");

        var attribute = node.GetAttributeOrDefault("label");

        Assert.IsNotNull(attribute);
    }

    [TestMethod]
    public void GetAttributeOrDefaultMissing()
    {
        var node = new DotNode();

        var attribute = node.GetAttributeOrDefault("label");

        Assert.IsNull(attribute);
    }

    [TestMethod]
    public void GetAttributeGenericWrongType()
    {
        var node = new DotNode()
            .WithLabel("Test");

        Assert.Throws<Exception>(() => node.GetAttribute<DotColorAttribute>("label"));
    }

    [TestMethod]
    public void GetAttributeOrDefaultGenericWrongType()
    {
        var node = new DotNode()
            .WithLabel("Test");

        Assert.Throws<Exception>(() => node.GetAttributeOrDefault<DotColorAttribute>("label"));
    }

    [TestMethod]
    public void GetAttributeOrDefaultGeneric()
    {
        var node = new DotNode();

        var attribute = node.GetAttributeOrDefault<DotLabelAttribute>("label");

        Assert.IsNull(attribute);
    }

    [TestMethod]
    public void SetAttributeToNull()
    {
        var node = new DotNode()
            .WithLabel("Test");

        node.SetAttribute("label", null);

        Assert.IsNull(node.Label);
    }

    [TestMethod]
    public void TryGetAttributeMissing()
    {
        var node = new DotNode();

        var success = node.TryGetAttribute("label", out var attribute);

        Assert.IsFalse(success);
        Assert.IsNull(attribute);
    }

    [TestMethod]
    public void TryGetAttributeGeneric()
    {
        var node = new DotNode()
            .WithLabel("Test");

        var success = node.TryGetAttribute<DotLabelAttribute>("label", out var attribute);

        Assert.IsTrue(success);
        Assert.IsNotNull(attribute);
    }

    [TestMethod]
    public void TryGetAttributeGenericMissing()
    {
        var node = new DotNode();

        var success = node.TryGetAttribute<DotLabelAttribute>("label", out var attribute);

        Assert.IsFalse(success);
        Assert.IsNull(attribute);
    }

    [TestMethod]
    public void TryGetAttributeGenericWrongType()
    {
        var node = new DotNode()
            .WithLabel("Test");

        Assert.Throws<Exception>(() => node.TryGetAttribute<DotColorAttribute>("label", out _));
    }
}