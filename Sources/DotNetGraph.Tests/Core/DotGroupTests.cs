using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Core;

[TestClass]
public class DotGroupTests
{
    [TestMethod]
    public async Task EmptyGroupElements()
    {
        var group = new DotGroup();

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await group.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("{\n}\n", result);
    }

    [TestMethod]
    public async Task GroupElementsAndAttributes()
    {
        var group = new DotGroup().WithAttribute("rank", "same");
        group.Add(new DotNode().WithIdentifier("node-1"));
        group.Add(new DotNode().WithIdentifier("node-2"));

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await group.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("{\n\t\"rank\"=same\n\t\"node-1\"\n\t\"node-2\"\n}\n", result);
    }
}