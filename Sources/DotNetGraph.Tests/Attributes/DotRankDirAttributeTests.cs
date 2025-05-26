using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotRankDirAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotRankDirAttribute("RL");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"RL\"", result);
    }

    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotRankDirAttribute(DotRankDir.TB);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"TB\"", result);
    }

    [TestMethod]
    public void ImplicitConversionFromDotRankDir()
    {
        DotRankDirAttribute attribute = DotRankDir.BT;
        Assert.AreEqual("BT", attribute.Value);
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotRankDirAttribute attribute = "LR";
        Assert.AreEqual("LR", attribute.Value);
    }
}