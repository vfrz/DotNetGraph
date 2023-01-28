using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Attributes
{
    public class DotAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotAttribute(string value)
        {
            Value = value;
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync(Value);
        }
    }
}