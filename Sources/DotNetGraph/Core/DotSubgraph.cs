using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotSubgraph : DotBaseGraph
    {
        public override async Task CompileAsync(CompilationContext context)
        {
            await context.WriteIndentationAsync();
            await context.WriteAsync("subgraph ");
            await Identifier.CompileAsync(context);
            await context.WriteLineAsync(" {");
            context.IndentationLevel++;
            await CompileAttributesAsync(context);
            context.IndentationLevel--;
            await context.WriteIndentationAsync();
            await context.WriteLineAsync("}");
        }
    }
}