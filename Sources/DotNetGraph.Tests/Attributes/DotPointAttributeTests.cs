using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotPointAttributeTests
{
    [TestMethod]
    public async Task CompileFromString()
    {
        var attribute = new DotPointAttribute("66,99");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("66,99", result);
    }

    [TestMethod]
    public async Task CompileFromDotPoint()
    {
        var attribute = new DotPointAttribute(new DotPoint(42, 69, 75, true));

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("42,69,75!", result);
    }

    [TestMethod]
    public void ImplicitConversionFromDotPoint()
    {
        DotPointAttribute attribute = new DotPoint(42, 69, 75, true);
        Assert.AreEqual("42,69,75!", attribute.Value);
    }

    [TestMethod]
    public void ImplicitConversionFromString()
    {
        DotPointAttribute attribute = "42,69,75!";
        Assert.AreEqual("42,69,75!", attribute.Value);
    }
}