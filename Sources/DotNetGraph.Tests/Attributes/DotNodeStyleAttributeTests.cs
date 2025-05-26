using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotNodeStyleAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotNodeStyleAttribute("custom");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"custom\"", result);
    }

    [TestMethod]
    public async Task CompileFromEnum()
    {
        var attribute = new DotNodeStyleAttribute(DotNodeStyle.Bold);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"bold\"", result);
    }

    [TestMethod]
    public void ImplicitConversionFromDotNodeStyle()
    {
        DotNodeStyleAttribute attribute = DotNodeStyle.Bold;
        Assert.AreEqual("bold", attribute.Value);
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotNodeStyleAttribute attribute = "bold";
        Assert.AreEqual("bold", attribute.Value);
    }
}