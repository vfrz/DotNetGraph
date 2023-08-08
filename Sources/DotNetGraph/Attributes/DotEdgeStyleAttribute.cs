using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotEdgeStyleAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotEdgeStyleAttribute(string value)
        {
            Value = value;
        }

        public DotEdgeStyleAttribute(DotEdgeStyle style)
        {
            Value = style.FlagsToString();
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync($"\"{Value}\"");
        }
        
        public static implicit operator DotEdgeStyleAttribute(DotEdgeStyle value) => new DotEdgeStyleAttribute(value);
        public static implicit operator DotEdgeStyleAttribute(string value) => new DotEdgeStyleAttribute(value);
    }
}