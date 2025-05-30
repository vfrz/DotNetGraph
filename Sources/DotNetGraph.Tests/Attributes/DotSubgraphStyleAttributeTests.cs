using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotSubgraphStyleAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotSubgraphStyleAttribute("custom");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"custom\"", result);
    }

    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotSubgraphStyleAttribute(DotSubgraphStyle.Rounded);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"rounded\"", result);
    }

    [TestMethod]
    public void ImplicitConversionFromDotSubgraphStyle()
    {
        DotSubgraphStyleAttribute attribute = DotSubgraphStyle.Rounded;
        Assert.AreEqual("rounded", attribute.Value);
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotSubgraphStyleAttribute attribute = "rounded";
        Assert.AreEqual("rounded", attribute.Value);
    }
}