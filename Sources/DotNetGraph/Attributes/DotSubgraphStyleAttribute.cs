using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotSubgraphStyleAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotSubgraphStyleAttribute(string value)
        {
            Value = value;
        }

        public DotSubgraphStyleAttribute(DotSubgraphStyle style)
        {
            Value = style.FlagsToString();
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync($"\"{Value}\"");
        }

        public static implicit operator DotSubgraphStyleAttribute(DotSubgraphStyle value) => new DotSubgraphStyleAttribute(value);
        public static implicit operator DotSubgraphStyleAttribute(string value) => new DotSubgraphStyleAttribute(value);
    }
}