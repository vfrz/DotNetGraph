using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class DotGraphExtensionsTests
{
    [TestMethod]
    public void Directed()
    {
        var graph = new DotGraph()
            .Directed();

        Assert.IsTrue(graph.Directed);
    }

    [TestMethod]
    public void NotDirected()
    {
        var graph = new DotGraph()
            .Directed(false);

        Assert.IsFalse(graph.Directed);
    }

    [TestMethod]
    public void Strict()
    {
        var graph = new DotGraph()
            .Strict();

        Assert.IsTrue(graph.Strict);
    }

    [TestMethod]
    public void NotStrict()
    {
        var graph = new DotGraph()
            .Strict(false);

        Assert.IsFalse(graph.Strict);
    }
}