using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotGroup : DotBaseGraph
    {
        public override async Task CompileAsync(CompilationContext context)
        {
            await context.WriteIndentationAsync();
            await context.WriteLineAsync("{");
            ++context.IndentationLevel;
            await CompileAttributesAsync(context);
            foreach (var element in Elements)
                await element.CompileAsync(context);
            --context.IndentationLevel;
            await context.WriteIndentationAsync();
            await context.WriteLineAsync("}");
        }
    }
}