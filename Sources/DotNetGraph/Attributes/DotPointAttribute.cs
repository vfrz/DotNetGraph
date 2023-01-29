using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotPointAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotPointAttribute(string value)
        {
            Value = value;
        }

        public DotPointAttribute(DotPoint point)
        {
            Value = point.ToString();
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync(Value);
        }
    }
}