using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Extensions;

namespace DotNetGraph.Core
{
    public class DotIdentifier : IDotElement
    {
        private static readonly Regex NoQuotesRequiredRegex
            = new Regex("^([a-zA-Z\\200-\\377_][a-zA-Z\\200-\\3770-9_]*|[-]?(.[0-9]+|[0-9]+(.[0-9]+)?))$");

        private static readonly string[] ReservedWords =
        {
            "graph",
            "digraph",
            "subgraph",
            "strict",
            "node",
            "edge"
        };

        public string Value { get; set; }

        public bool IsHtml { get; set; } = false;

        public DotIdentifier(string value, bool isHtml = false)
        {
            Value = value;
            IsHtml = isHtml;
        }

        public async Task CompileAsync(CompilationContext context)
        {
            if (IsHtml)
            {
                await context.TextWriter.WriteAsync($"<{Value}>");
                return;
            }

            var value = context.Options.AutomaticEscapedCharactersFormat ? Value.FormatGraphvizEscapedCharacters() : Value;
            if (RequiresDoubleQuotes(value))
                await context.TextWriter.WriteAsync($"\"{value}\"");
            else
                await context.TextWriter.WriteAsync($"{value}");
        }

        private static bool RequiresDoubleQuotes(string value)
        {
            return ReservedWords.Contains(value) || !NoQuotesRequiredRegex.IsMatch(value);
        }
    }
}