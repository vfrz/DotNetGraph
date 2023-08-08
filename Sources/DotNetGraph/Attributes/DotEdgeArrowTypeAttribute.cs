using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotEdgeArrowTypeAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotEdgeArrowTypeAttribute(string value)
        {
            Value = value;
        }

        public DotEdgeArrowTypeAttribute(DotEdgeArrowType type)
        {
            Value = type.ToString().ToLowerInvariant();
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync($"\"{Value}\"");
        }

        public static implicit operator DotEdgeArrowTypeAttribute(DotEdgeArrowType value) => new DotEdgeArrowTypeAttribute(value);
        public static implicit operator DotEdgeArrowTypeAttribute(string value) => new DotEdgeArrowTypeAttribute(value);
    }
}