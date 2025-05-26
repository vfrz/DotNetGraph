using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotGraphTests
{
    [TestMethod]
    public async Task CompileEmptyGraph()
    {
        var graph = new DotGraph()
            .WithIdentifier("Test");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await graph.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("graph Test {\n}\n", result);
    }

    [TestMethod]
    public async Task CompileEmptyStrictGraph()
    {
        var graph = new DotGraph()
            .WithIdentifier("Test")
            .Strict();

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await graph.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("strict graph Test {\n}\n", result);
    }

    [TestMethod]
    public async Task CompileEmptyDirectedGraph()
    {
        var graph = new DotGraph()
            .WithIdentifier("Test")
            .Directed();

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await graph.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("digraph Test {\n}\n", result);
    }

    [TestMethod]
    public async Task CompileEmptyDirectedGraphWithRankDir()
    {
        var graph = new DotGraph()
            .WithIdentifier("Test")
            .WithRankDir(DotRankDir.RL)
            .Directed();

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await graph.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("digraph Test {\n\t\"rankdir\"=\"RL\"\n}\n", result);
    }

    [TestMethod]
    public async Task CompileDirectedGraphWithOneNode()
    {
        var node = new DotNode()
            .WithIdentifier("TestNode");

        var graph = new DotGraph()
            .WithIdentifier("Test")
            .Directed()
            .Add(node);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await graph.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("digraph Test {\n\tTestNode\n}\n", result);
    }

    [TestMethod]
    public void GetNodeByIdentifier()
    {
        var node = new DotNode()
            .WithIdentifier("TestNode");

        var graph = new DotGraph()
            .WithIdentifier("Test")
            .Directed()
            .Add(node);

        var nodeFromGraph = graph.GetNodeByIdentifier("TestNode");

        Assert.AreSame(node, nodeFromGraph);
    }

    [TestMethod]
    public void GetNodeByIdentifier_MissingNode()
    {
        var node = new DotNode()
            .WithIdentifier("TestNode");

        var graph = new DotGraph()
            .WithIdentifier("Test")
            .Directed()
            .Add(node);

        var nodeFromGraph = graph.GetNodeByIdentifier("NotTestNode");

        Assert.IsNull(nodeFromGraph);
    }
}