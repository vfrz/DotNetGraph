using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
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

        graph.Directed.Should().Be(true);
    }
    
    [TestMethod]
    public void Strict()
    {
        var graph = new DotGraph()
            .Strict();

        graph.Strict.Should().Be(true);
    }
}