using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotDoubleAttributeTests
{
    [TestMethod]
    public async Task RenderWithDefaultFormat()
    {
        var attribute = new DotDoubleAttribute(123.456);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("123.46");
    }

    [TestMethod]
    public async Task RenderWithSpecifiedFormat()
    {
        var attribute = new DotDoubleAttribute(123.456, "F3");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("123.456");
    }
}