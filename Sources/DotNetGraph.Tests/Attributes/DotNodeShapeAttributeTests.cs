using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotNodeShapeAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotNodeShapeAttribute("custom");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"custom\"");
    }
    
    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotNodeShapeAttribute(DotNodeShape.Terminator);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"terminator\"");
    }
    
    [TestMethod]
    public void ImplicitConversionFromDotNodeShape()
    {
        DotNodeShapeAttribute attribute = DotNodeShape.Terminator;
        attribute.Value.Should().Be("terminator");
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotNodeShapeAttribute attribute = "terminator";
        attribute.Value.Should().Be("terminator");
    }
}