using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotColorAttributeTests
{
    [TestMethod]
    public async Task RenderFromString()
    {
        var attribute = new DotColorAttribute("red");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"red\"");
    }
    
    [TestMethod]
    public async Task RenderFromColor()
    {
        var attribute = new DotColorAttribute(Color.Red);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"#FF0000\"");
    }
}