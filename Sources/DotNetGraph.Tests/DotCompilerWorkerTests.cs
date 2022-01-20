using DotNetGraph.Compiler;
using NFluent;
using Xunit;

namespace DotNetGraph.Tests
{
    public class DotCompilerWorkerTests
    {
        [Fact]
        public void Format()
        {
            const string text = "Je m'appelle \"Jack\",\r\n je suis un test\\essai\nCela marche!";

            var formatted = DotCompilerWorker.FormatString(text);

            Check.That(formatted).HasSameValueAs("Je m'appelle \\\"Jack\\\",\\n je suis un test\\\\essai\\nCela marche!");
        }

        [Theory]
        [InlineData("node")]
        [InlineData("node123")]
        [InlineData("underscores_are_allowed")]
        [InlineData("-123")]
        [InlineData("123")]
        [InlineData("1.23")]
        [InlineData("-1.23")]
        public void SurroundWithDoubleQuotes_Without(string text)
        {
            var formatted = DotCompilerWorker.SurroundStringWithQuotes(text);

            Check.That(formatted).HasSameValueAs(text);
        }

        [Theory]
        [InlineData("no[]de")]
        [InlineData("no\"de")]
        [InlineData("no\nde")]
        [InlineData("123start_with_number")]
        [InlineData("identifier with space")]
        [InlineData("\"node\"")]
        [InlineData("節点")]
        [InlineData("узел")]
        [InlineData("1a")]
        [InlineData("-1a")]
        [InlineData("1.1a")]
        [InlineData("-1.1a")]
        public void SurroundWithDoubleQuotes_With(string text)
        {
            var formatted = DotCompilerWorker.SurroundStringWithQuotes(text);

            Check.That(formatted).HasSameValueAs("\"" + text + "\"");
        }
    }
}