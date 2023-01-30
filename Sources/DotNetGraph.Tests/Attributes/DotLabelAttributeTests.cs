using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotLabelAttributeTests
{
    [TestMethod]
    public async Task RenderDefault()
    {
        var attribute = new DotLabelAttribute("Hello,\r\n \"world\"!");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"Hello,\\n \\\"world\\\"!\"");
    }

    [TestMethod]
    public async Task RenderWithoutAutomaticEscapedCharactersFormat()
    {
        var attribute = new DotLabelAttribute("Hello,\r\n \"world\"!");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions
        {
            AutomaticEscapedCharactersFormat = false
        });
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"Hello,\r\n \"world\"!\"");
    }
    
    [TestMethod]
    public async Task RenderHtml()
    {
        var attribute = new DotLabelAttribute("<b>Hello, world!</b>", true);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("<<b>Hello, world!</b>>");
    }
}