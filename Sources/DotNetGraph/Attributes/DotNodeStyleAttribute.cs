using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotNodeStyleAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotNodeStyleAttribute(string value)
        {
            Value = value;
        }

        public DotNodeStyleAttribute(DotNodeStyle style)
        {
            Value = style.FlagsToString();
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync($"\"{Value}\"");
        }
        
        public static implicit operator DotNodeStyleAttribute(DotNodeStyle value) => new DotNodeStyleAttribute(value);
        public static implicit operator DotNodeStyleAttribute(string value) => new DotNodeStyleAttribute(value);
    }
}