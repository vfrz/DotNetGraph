using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotIdentifierTests
{
    [TestMethod]
    public async Task Compile()
    {
        var identifier = new DotIdentifier("Test");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await identifier.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("Test");
    }

    [TestMethod]
    public async Task CompileWithQuotes()
    {
        var identifier = new DotIdentifier("Hello, world!");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await identifier.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("\"Hello, world!\"");
    }

    [DataTestMethod]
    [DataRow("graph")]
    [DataRow("digraph")]
    [DataRow("subgraph")]
    [DataRow("strict")]
    [DataRow("node")]
    [DataRow("edge")]
    public async Task CompileWithQuotesReservedWords(string identifierValue)
    {
        var identifier = new DotIdentifier(identifierValue);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await identifier.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be($"\"{identifierValue}\"");
    }
    
    [TestMethod]
    public async Task CompileHtml()
    {
        var identifier = new DotIdentifier("<b>Test</b>", true);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await identifier.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("<<b>Test</b>>");
    }
}