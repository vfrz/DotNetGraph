using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Compilation;

[TestClass]
public class CompilationContextTests
{
    [TestMethod]
    public async Task WriteIndentationAsyncIndentedLevel3()
    {
        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions
        {
            Indented = true
        })
        {
            IndentationLevel = 3
        };
        await context.WriteIndentationAsync();

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\t\t\t", result);
    }

    [TestMethod]
    public async Task WriteIndentationAsyncNonIndentedLevel3()
    {
        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions
        {
            Indented = false
        })
        {
            IndentationLevel = 3
        };
        await context.WriteIndentationAsync();

        var result = writer.GetStringBuilder().ToString();
        Assert.IsTrue(string.IsNullOrEmpty(result));
    }

    [TestMethod]
    public async Task WriteAsync()
    {
        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());

        await context.WriteAsync("Hello, world!");

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("Hello, world!", result);
    }

    [TestMethod]
    public async Task WriteLineAsyncIndented()
    {
        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions
        {
            Indented = true
        });

        await context.WriteLineAsync("Hello, world!");

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("Hello, world!\n", result);
    }

    [TestMethod]
    public async Task WriteLineAsyncNonIndented()
    {
        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions
        {
            Indented = false
        });

        await context.WriteLineAsync("Hello, world!");

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("Hello, world! ", result);
    }
}