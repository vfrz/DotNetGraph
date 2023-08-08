using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public abstract class DotBaseGraph : DotElement
    {
        public DotIdentifier Identifier { get; set; }
        
        public DotRankDir? RankDir { get; set; }

        public List<IDotElement> Elements { get; } = new List<IDotElement>();

        public abstract override Task CompileAsync(CompilationContext context);

        protected async Task CompileBodyAsync(CompilationContext context)
        {
            await Identifier.CompileAsync(context);
            await context.WriteLineAsync(" {");
            context.IndentationLevel++;
            if (RankDir != null)
            {
                await context.WriteIndentationAsync();
                await context.WriteLineAsync($"rankdir=\"{RankDir.ToString()}\"");
            }
            await CompileAttributesAsync(context);
            context.IndentationLevel--;
            await context.WriteIndentationAsync();
            await context.WriteLineAsync("}");
        }
    }
}