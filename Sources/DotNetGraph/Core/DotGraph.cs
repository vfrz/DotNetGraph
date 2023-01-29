using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotGraph : DotBaseGraph
    {
        public bool Strict { get; set; } = false;

        public bool Directed { get; set; } = false;

        public override async Task CompileAsync(CompilationContext context)
        {
            context.DirectedGraph = Directed;
            await context.WriteIndentationAsync();
            if (Strict)
                await context.WriteAsync("strict ");
            await context.WriteAsync(Directed ? "digraph " : "graph ");
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