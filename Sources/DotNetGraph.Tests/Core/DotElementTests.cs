using System;
using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
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

        hasAttribute.Should().BeTrue();
    }

    [TestMethod]
    public void HasAttributeFalse()
    {
        var node = new DotNode();

        var hasAttribute = node.HasAttribute("label");

        hasAttribute.Should().BeFalse();
    }

    [TestMethod]
    public void GetAttributeMissing()
    {
        var node = new DotNode();

        node.Invoking(n => n.GetAttribute("label"))
            .Should()
            .Throw<Exception>();
    }

    [TestMethod]
    public void GetAttributeOrDefault()
    {
        var node = new DotNode()
            .WithLabel("Test");

        var attribute = node.GetAttributeOrDefault("label");

        attribute.Should().NotBeNull();
    }

    [TestMethod]
    public void GetAttributeOrDefaultMissing()
    {
        var node = new DotNode();

        var attribute = node.GetAttributeOrDefault("label");

        attribute.Should().BeNull();
    }

    [TestMethod]
    public void GetAttributeGenericWrongType()
    {
        var node = new DotNode()
            .WithLabel("Test");

        node.Invoking(n => n.GetAttribute<DotColorAttribute>("label"))
            .Should()
            .Throw<Exception>();
    }

    [TestMethod]
    public void GetAttributeOrDefaultGenericWrongType()
    {
        var node = new DotNode()
            .WithLabel("Test");

        node.Invoking(n => n.GetAttributeOrDefault<DotColorAttribute>("label"))
            .Should()
            .Throw<Exception>();
    }

    [TestMethod]
    public void GetAttributeOrDefaultGeneric()
    {
        var node = new DotNode();

        var attribute = node.GetAttributeOrDefault<DotLabelAttribute>("label");

        attribute.Should().BeNull();
    }

    [TestMethod]
    public void SetAttributeToNull()
    {
        var node = new DotNode()
            .WithLabel("Test");

        node.SetAttribute("label", null);

        node.Label.Should().BeNull();
    }

    [TestMethod]
    public void TryGetAttributeMissing()
    {
        var node = new DotNode();

        var success = node.TryGetAttribute("label", out var attribute);

        success.Should().BeFalse();
        attribute.Should().BeNull();
    }

    [TestMethod]
    public void TryGetAttributeGeneric()
    {
        var node = new DotNode()
            .WithLabel("Test");

        var success = node.TryGetAttribute<DotLabelAttribute>("label", out var attribute);

        success.Should().BeTrue();
        attribute.Should().NotBeNull();
    }

    [TestMethod]
    public void TryGetAttributeGenericMissing()
    {
        var node = new DotNode();

        var success = node.TryGetAttribute<DotLabelAttribute>("label", out var attribute);

        success.Should().BeFalse();
        attribute.Should().BeNull();
    }

    [TestMethod]
    public void TryGetAttributeGenericWrongType()
    {
        var node = new DotNode()
            .WithLabel("Test");

        node.Invoking(n => node.TryGetAttribute<DotColorAttribute>("label", out _))
            .Should()
            .Throw<Exception>();
    }
}