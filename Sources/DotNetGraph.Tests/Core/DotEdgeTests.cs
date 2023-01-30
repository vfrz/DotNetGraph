using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using FluentAssertions;
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
        result.Should().Be("\"A\" -- \"B\"\n");
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
        result.Should().Be("\"A\" -> \"B\"\n");
    }
}