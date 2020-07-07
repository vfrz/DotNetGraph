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
            var text = "Je m'appelle \"Jack\",\r\n je suis un test\\essai\nCela marche!";

            var formatted = DotCompiler.FormatString(text, true);

            Check.That(formatted).HasSameValueAs("Je m'appelle \\\"Jack\\\",\\n je suis un test\\\\essai\\nCela marche!");
        }

        [Fact]
        public void Format_Disabled()
        {
            var text = "Je m'appelle \"Jack\",\r\n je suis un test\\essai\nCela marche!";

            var formatted = DotCompiler.FormatString(text, false);

            Check.That(formatted).HasSameValueAs(text);
        }
    }
}