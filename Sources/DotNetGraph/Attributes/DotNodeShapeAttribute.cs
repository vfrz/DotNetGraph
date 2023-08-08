using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotNodeShapeAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotNodeShapeAttribute(string value)
        {
            Value = value;
        }

        public DotNodeShapeAttribute(DotNodeShape shape)
        {
            Value = shape.ToString().ToLowerInvariant();
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync($"\"{Value}\"");
        }
        
        public static implicit operator DotNodeShapeAttribute(DotNodeShape value) => new DotNodeShapeAttribute(value);
        public static implicit operator DotNodeShapeAttribute(string value) => new DotNodeShapeAttribute(value);
    }
}