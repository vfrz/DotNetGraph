using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotNodeTests
{
    [TestMethod]
    public async Task CompileEmptyNode()
    {
        var node = new DotNode()
            .WithIdentifier("Test");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await node.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("Test\n");
    }

    [TestMethod]
    public async Task CompileNodeWithColor()
    {
        var node = new DotNode()
            .WithIdentifier("Test")
            .WithColor(DotColor.Red);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await node.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("Test [\n\t\"color\"=\"#FF0000\"\n]\n");
    }

    [TestMethod]
    public async Task CompileNodesProperties()
    {
        var node = new DotNode()
            .WithIdentifier("node", quoteReservedWords: false).WithStyle(DotNodeStyle.Filled);
        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await node.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        result.Should().Be("node [\n\t\"style\"=\"filled\"\n]\n");
    }
}