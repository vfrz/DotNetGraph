using DotNetGraph.Compiler;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests
{
    public class DotCompilerTests
    {
        [Fact]
        public void Format()
        {
            const string text = "Je m'appelle \"Jack\",\r\n je suis un test\\essai\nCela marche!";

            var formatted = DotCompiler.FormatString(text, true);

            Check.That(formatted).HasSameValueAs("Je m'appelle \\\"Jack\\\",\\n je suis un test\\\\essai\\nCela marche!");
        }

        [Fact]
        public void Format_Disabled()
        {
            const string text = "Je m'appelle \"Jack\",\r\n je suis un test\\essai\nCela marche!";

            var formatted = DotCompiler.FormatString(text, false);

            Check.That(formatted).HasSameValueAs(text);
        }

        [Theory]
        [InlineData("node")]
        [InlineData("node123")]
        [InlineData("узел")]
        [InlineData("節点")]
        public void SurroundWithDoubleQuotes_Without(string text)
        {
            var formatted = DotCompiler.SurroundStringWithQuotes(text, false);

            Check.That(formatted).HasSameValueAs(text);
        }

        [Theory]
        [InlineData("no[]de")]
        [InlineData("no\"de")]
        [InlineData("no\nde")]
        [InlineData("identifier with space")]
        [InlineData("\"node\"")]
        [InlineData("節+点")]
        public void SurroundWithDoubleQuotes_With(string text)
        {
            var formatted = DotCompiler.SurroundStringWithQuotes(text, false);

            Check.That(formatted).HasSameValueAs("\"" + text + "\"");
        }
    }
}