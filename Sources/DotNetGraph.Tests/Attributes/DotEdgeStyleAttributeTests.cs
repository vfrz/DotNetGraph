using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotEdgeStyleAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotEdgeStyleAttribute("custom");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"custom\"", result);
    }

    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotEdgeStyleAttribute(DotEdgeStyle.Solid);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"solid\"", result);
    }

    [TestMethod]
    public void ImplicitConversionFromDotEdgeStyle()
    {
        DotEdgeStyleAttribute attribute = DotEdgeStyle.Solid;
        Assert.AreEqual("solid", attribute.Value);
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotEdgeStyleAttribute attribute = "solid";
        Assert.AreEqual("solid", attribute.Value);
    }
}