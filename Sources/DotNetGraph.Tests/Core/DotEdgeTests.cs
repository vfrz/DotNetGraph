using System;
using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotEdgeTests
{
    [TestMethod]
    public async Task CompileEmptyEdge()
    {
        var edge = new DotEdge()
            .From("A")
            .To("B");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await edge.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("A -- B\n", result);
    }

    [TestMethod]
    public async Task CompileEmptyDirectedEdge()
    {
        var edge = new DotEdge()
            .From("A")
            .To("B");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions())
        {
            DirectedGraph = true
        };
        await edge.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("A -> B\n", result);
    }

    [TestMethod]
    public async Task CompileWithMissingFrom()
    {
        var edge = new DotEdge()
            .To("B");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions())
        {
            DirectedGraph = true
        };

        await Assert.ThrowsAsync<Exception>(() => edge.CompileAsync(context));
    }

    [TestMethod]
    public async Task CompileWithMissingTo()
    {
        var edge = new DotEdge()
            .From("A");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions())
        {
            DirectedGraph = true
        };

        await Assert.ThrowsAsync<Exception>(() => edge.CompileAsync(context));
    }

    [TestMethod]
    public async Task CompileWithAttributes()
    {
        var edge = new DotEdge()
            .From("A")
            .To("B")
            .WithLabel("Test")
            .WithStyle(DotEdgeStyle.Bold);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions())
        {
            DirectedGraph = true
        };
        await edge.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("A -> B [\n\t\"label\"=\"Test\"\n\t\"style\"=\"bold\"\n]\n", result);
    }
}