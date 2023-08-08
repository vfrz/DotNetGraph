using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotRankDirAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotRankDirAttribute("RL");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"RL\"");
    }

    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotRankDirAttribute(DotRankDir.TB);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"TB\"");
    }

    [TestMethod]
    public void ImplicitConversionFromDotRankDir()
    {
        DotRankDirAttribute attribute = DotRankDir.TB;
        attribute.Value.Should().Be("TB");
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotRankDirAttribute attribute = "BT";
        attribute.Value.Should().Be("BT");
    }
}