using DotNetGraph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class StringExtensionsTests
{
    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("Hello,\r\n world!", "Hello,\\n world!")]
    [DataRow("Hello,\n world!", "Hello,\\n world!")]
    [DataRow("Hello, \"world\"!", "Hello, \\\"world\\\"!")]
    [DataRow("C:\\", "C:\\\\")]
    public void FormatGraphvizEscapedCharacters(string input, string expectedOutput)
    {
        var result = input.FormatGraphvizEscapedCharacters();

        Assert.AreEqual(expectedOutput, result);
    }
}