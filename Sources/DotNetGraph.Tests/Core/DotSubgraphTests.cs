using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotSubgraphTests
{
    [TestMethod]
    public async Task CompileEmptySubgraph()
    {
        var subgraph = new DotSubgraph()
            .WithIdentifier("Test");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await subgraph.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("subgraph Test {\n}\n", result);
    }
}