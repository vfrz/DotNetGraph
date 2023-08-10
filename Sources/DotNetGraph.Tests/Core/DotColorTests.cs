using DotNetGraph.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotColorTests
{
    [DataTestMethod]
    [DataRow(255, 0, 0, 255, 0, 0, 255, 255, false)]
    [DataRow(128, 15, 255, 255, 128, 15, 255, 255, true)]
    public void EqualsWithAnother(int r1, int g1, int b1, int a1, int r2, int g2, int b2, int a2, bool expectedEqual)
    {
        var color1 = new DotColor((byte) r1, (byte) g1, (byte) b1, (byte) a1);
        var color2 = new DotColor((byte) r2, (byte) g2, (byte) b2, (byte) a2);

        var equal = color1.Equals(color2);

        equal.Should().Be(expectedEqual);
    }

    [TestMethod]
    public void ToHexStringRgb()
    {
        var color = new DotColor(123, 123, 255);

        var hex = color.ToHexString();

        hex.Should().Be("#7B7BFF");
    }

    [TestMethod]
    public void ToHexStringRgba()
    {
        var color = new DotColor(123, 123, 255, 123);

        var hex = color.ToHexString();

        hex.Should().Be("#7B7BFF7B");
    }
}