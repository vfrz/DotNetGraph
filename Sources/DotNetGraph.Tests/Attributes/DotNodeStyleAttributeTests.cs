using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotNodeStyleAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotNodeStyleAttribute("custom");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"custom\"");
    }
    
    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotNodeStyleAttribute(DotNodeStyle.Bold);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"bold\"");
    }
    
    [TestMethod]
    public void ImplicitConversionFromDotNodeStyle()
    {
        DotNodeStyleAttribute attribute = DotNodeStyle.Bold;
        attribute.Value.Should().Be("bold");
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotNodeStyleAttribute attribute = "bold";
        attribute.Value.Should().Be("bold");
    }
}