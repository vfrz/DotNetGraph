using System.Drawing;
using DotNetGraph.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class ColorExtensionsTests
{
    [TestMethod]
    public void ToHexStringRgb()
    {
        var color = Color.FromArgb(123, 123, 255);

        var hex = color.ToHexString();

        hex.Should().Be("#7B7BFF");
    }
    
    [TestMethod]
    public void ToHexStringRgba()
    {
        var color = Color.FromArgb(123, 123, 123, 255);

        var hex = color.ToHexString();

        hex.Should().Be("#7B7BFF7B");
    }
}