using System.Drawing;
using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotColorAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotColorAttribute(Color color)
        {
            Value = color.ToHexString();
        }

        public DotColorAttribute(string value)
        {
            Value = value;
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync($"\"{Value}\"");
        }
    }
}