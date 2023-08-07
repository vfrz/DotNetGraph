using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotSubgraph : DotBaseGraph
    {
        public DotColorAttribute Color
        {
            get => GetAttributeOrDefault<DotColorAttribute>("color");
            set => SetAttribute("color", value);
        }
        
        public DotSubgraphStyleAttribute Style
        {
            get => GetAttributeOrDefault<DotSubgraphStyleAttribute>("style");
            set => SetAttribute("style", value);
        }

        public override async Task CompileAsync(CompilationContext context)
        {
            await context.WriteIndentationAsync();
            await context.WriteAsync("subgraph ");
            await CompileBodyAsync(context);
        }
    }
}