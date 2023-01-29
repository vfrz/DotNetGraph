using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotEdge : DotElement
    {
        public DotIdentifier From { get; set; }

        public DotIdentifier To { get; set; }

        public DotColorAttribute Color
        {
            get => GetAttributeOrDefault<DotColorAttribute>("color");
            set => SetAttribute("color", value);
        }

        public DotEdgeStyleAttribute Style
        {
            get => GetAttributeOrDefault<DotEdgeStyleAttribute>("style");
            set => SetAttribute("style", value);
        }

        public DotDoubleAttribute PenWidth
        {
            get => GetAttribute<DotDoubleAttribute>("penwidth");
            set => SetAttribute("penwidth", value);
        }

        public DotEdgeArrowTypeAttribute ArrowHead
        {
            get => GetAttribute<DotEdgeArrowTypeAttribute>("arrowhead");
            set => SetAttribute("arrowhead", value);
        }

        public DotEdgeArrowTypeAttribute ArrowTail
        {
            get => GetAttribute<DotEdgeArrowTypeAttribute>("arrowtail");
            set => SetAttribute("arrowtail", value);
        }
        
        public DotPointAttribute Pos
        {
            get => GetAttribute<DotPointAttribute>("pos");
            set => SetAttribute("pos", value);
        }

        public override async Task CompileAsync(CompilationContext context)
        {
            if (From is null || To is null)
                throw new Exception("Can't compile edge with null From and/or To");

            await context.WriteIndentationAsync();
            await From.CompileAsync(context);
            await context.WriteAsync($" {(context.DirectedGraph ? "->" : "--")} ");
            await To.CompileAsync(context);
            if (Attributes.Any())
            {
                await context.WriteLineAsync(" [");
                context.IndentationLevel++;
                await CompileAttributesAsync(context);
                context.IndentationLevel--;
                await context.WriteIndentationAsync();
                await context.WriteLineAsync("]");
            }
            else
            {
                await context.WriteLineAsync();
            }
        }
    }
}