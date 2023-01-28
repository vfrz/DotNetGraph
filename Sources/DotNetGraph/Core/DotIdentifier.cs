using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Extensions;

namespace DotNetGraph.Core
{
    public class DotIdentifier : IDotElement
    {
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
                await context.TextWriter.WriteAsync($"<{Value}>");
            
            var value = context.Options.AutomaticEscapedCharactersFormat ? Value.FormatGraphvizEscapedCharacters() : Value;
            await context.TextWriter.WriteAsync($"\"{value}\"");
        }
    }
}