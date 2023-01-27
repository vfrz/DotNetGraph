using DotNetGraph.Compilation;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotLabelAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public bool IsHtml { get; set; } = false;

        public DotLabelAttribute(string value, bool isHtml = false)
        {
            Value = value;
            IsHtml = isHtml;
        }

        public string Compile(CompilationOptions options)
        {
            if (IsHtml)
                return $"<{Value}>";
            
            var value = options.AutomaticEscapedCharactersFormat ? Value.FormatGraphvizEscapedCharacters() : Value;
            return $"\"{value}\"";
        }
    }
}