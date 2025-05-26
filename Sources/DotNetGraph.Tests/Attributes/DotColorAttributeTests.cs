using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotColorAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotColorAttribute("red");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"red\"", result);
    }

    [TestMethod]
    public async Task CompileFromColor()
    {
        var attribute = new DotColorAttribute(DotColor.Red);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("\"#FF0000\"", result);
    }

    [TestMethod]
    public void ImplicitConversionFromColor()
    {
        DotColorAttribute attribute = DotColor.Red;
        Assert.AreEqual("#FF0000", attribute.Value);
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotColorAttribute attribute = "#FF0000";
        Assert.AreEqual("#FF0000", attribute.Value);
    }
}