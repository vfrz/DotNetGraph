using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotEdgeArrowTypeAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotEdgeArrowTypeAttribute("custom");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"custom\"");
    }
    
    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotEdgeArrowTypeAttribute(DotEdgeArrowType.Box);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"box\"");
    }
    
    [TestMethod]
    public void ImplicitConversionFromDotEdgeArrowType()
    {
        DotEdgeArrowTypeAttribute attribute = DotEdgeArrowType.Box;
        attribute.Value.Should().Be("box");
    }
    
    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotEdgeArrowTypeAttribute attribute = "box";
        attribute.Value.Should().Be("box");
    }
}