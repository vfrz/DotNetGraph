using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public abstract class DotBaseGraph : DotElement
    {
        public DotIdentifier Identifier { get; set; }

        public DotRankDirAttribute RankDir
        {
            get => GetAttributeOrDefault<DotRankDirAttribute>("rankdir");
            set => SetAttribute("rankdir", value);
        }

        public List<IDotElement> Elements { get; } = new List<IDotElement>();

        public abstract override Task CompileAsync(CompilationContext context);

        protected async Task CompileBodyAsync(CompilationContext context)
        {
            await Identifier.CompileAsync(context);
            await context.WriteLineAsync(" {");
            context.IndentationLevel++;
            await CompileAttributesAsync(context);
            foreach (var element in Elements)
                await element.CompileAsync(context);
            context.IndentationLevel--;
            await context.WriteIndentationAsync();
            await context.WriteLineAsync("}");
        }
    }
}