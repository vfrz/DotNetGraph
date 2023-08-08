using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotLabelAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public bool IsHtml { get; set; }

        public DotLabelAttribute(string value, bool isHtml = false)
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
            await context.TextWriter.WriteAsync($"\"{value}\"");
        }
        
        public static implicit operator DotLabelAttribute(string value) => new DotLabelAttribute(value);
    }
}