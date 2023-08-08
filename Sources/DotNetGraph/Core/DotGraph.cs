using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotGraph : DotBaseGraph
    {
        public bool Strict { get; set; }

        public bool Directed { get; set; }
        
        public override async Task CompileAsync(CompilationContext context)
        {
            context.DirectedGraph = Directed;
            await context.WriteIndentationAsync();
            if (Strict)
                await context.WriteAsync("strict ");
            await context.WriteAsync(Directed ? "digraph " : "graph ");
            await CompileBodyAsync(context);
        }
    }
}