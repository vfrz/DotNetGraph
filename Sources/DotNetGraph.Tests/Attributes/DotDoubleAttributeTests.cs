using System.IO;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Attributes;

[TestClass]
public class DotDoubleAttributeTests
{
    [TestMethod]
    public async Task CompileWithDefaultFormat()
    {
        var attribute = new DotDoubleAttribute(123.456);

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("123.46", result);
    }

    [TestMethod]
    public async Task CompileWithSpecifiedFormat()
    {
        var attribute = new DotDoubleAttribute(123.456, "F3");

        await using var writer = new StringWriter();
        var context = new CompilationContext(writer, new CompilationOptions());
        await attribute.CompileAsync(context);

        var result = writer.GetStringBuilder().ToString();
        Assert.AreEqual("123.456", result);
    }

    [TestMethod]
    public void ImplicitConversionFromDouble()
    {
        DotDoubleAttribute attribute = 123.456d;
        Assert.AreEqual(123.456d, attribute.Value);
    }
}