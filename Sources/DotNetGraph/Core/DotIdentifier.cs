using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Extensions;

namespace DotNetGraph.Core
{
    public class DotIdentifier : IDotElement, IEquatable<DotIdentifier>
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

        public bool Equals(DotIdentifier other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Value == other.Value && IsHtml == other.IsHtml;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((DotIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ IsHtml.GetHashCode();
            }
        }
        
        public static bool operator ==(DotIdentifier identifier1, DotIdentifier identifier2)
        {
            if (identifier1 is null)
                return identifier2 is null;
            return identifier1.Equals(identifier2);
        }

        public static bool operator !=(DotIdentifier identifier1, DotIdentifier identifier2) => !(identifier1 == identifier2);
    }
}