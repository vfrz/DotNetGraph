using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotColorAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotColorAttribute(DotColor color)
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
        
        public static implicit operator DotColorAttribute(DotColor value) => new DotColorAttribute(value);
        public static implicit operator DotColorAttribute(string value) => new DotColorAttribute(value);
    }
}