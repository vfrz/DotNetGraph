using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotLabelAttributeTests
{
    [TestMethod]
    public async Task CompileDefault()
    {
        var attribute = new DotLabelAttribute("Hello,\r\n \"world\"!");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"Hello,\\n \\\"world\\\"!\"", result);
    }

    [TestMethod]
    public async Task CompileWithoutAutomaticEscapedCharactersFormat()
    {
        var attribute = new DotLabelAttribute("Hello,\r\n \"world\"!");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions
        {
            AutomaticEscapedCharactersFormat = false
        });
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"Hello,\r\n \"world\"!\"", result);
    }

    [TestMethod]
    public async Task CompileHtml()
    {
        var attribute = new DotLabelAttribute("<b>Hello, world!</b>", true);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("<<b>Hello, world!</b>>", result);
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotLabelAttribute attribute = "Hello, world!";
        Assert.AreEqual("Hello, world!", attribute.Value);
        Assert.IsFalse(attribute.IsHtml);
    }
}