using System.Threading.Tasks;
using DotNetGraph.Compilation;
using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotRankDirAttribute : IDotAttribute
    {
        public string Value { get; set; }

        public DotRankDirAttribute(string value)
        {
            Value = value;
        }

        public DotRankDirAttribute(DotRankDir rankDir)
        {
            Value = rankDir.ToString();
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync($"\"{Value}\"");
        }
        
        public static implicit operator DotRankDirAttribute(DotRankDir value) => new DotRankDirAttribute(value);
        public static implicit operator DotRankDirAttribute(string value) => new DotRankDirAttribute(value);
    }
}