using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotEdgeStyleAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotEdgeStyleAttribute("custom");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"custom\"");
    }

    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotEdgeStyleAttribute(DotEdgeStyle.Solid);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"solid\"");
    }

    [TestMethod]
    public void ImplicitConversionFromDotEdgeStyle()
    {
        DotEdgeStyleAttribute attribute = DotEdgeStyle.Solid;
        attribute.Value.Should().Be("solid");
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotEdgeStyleAttribute attribute = "solid";
        attribute.Value.Should().Be("solid");
    }
}