using System.Linq;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotNode : DotElement
    {
        public DotIdentifier Identifier { get; set; }

        public DotColorAttribute Color
        {
            get => GetAttributeOrDefault<DotColorAttribute>("color");
            set => SetAttribute("color", value);
        }
        
        public DotColorAttribute FillColor
        {
            get => GetAttributeOrDefault<DotColorAttribute>("fillcolor");
            set => SetAttribute("fillcolor", value);
        }

        public DotNodeShapeAttribute Shape
        {
            get => GetAttributeOrDefault<DotNodeShapeAttribute>("shape");
            set => SetAttribute("shape", value);
        }

        public DotNodeStyleAttribute Style
        {
            get => GetAttributeOrDefault<DotNodeStyleAttribute>("style");
            set => SetAttribute("style", value);
        }
        
        public DotDoubleAttribute Width
        {
            get => GetAttribute<DotDoubleAttribute>("width");
            set => SetAttribute("width", value);
        }

        public DotDoubleAttribute Height
        {
            get => GetAttribute<DotDoubleAttribute>("height");
            set => SetAttribute("height", value);
        }

        public DotDoubleAttribute PenWidth
        {
            get => GetAttribute<DotDoubleAttribute>("penwidth");
            set => SetAttribute("penwidth", value);
        }

        public DotPointAttribute Pos
        {
            get => GetAttribute<DotPointAttribute>("pos");
            set => SetAttribute("pos", value);
        }

        public override async Task CompileAsync(CompilationContext context)
        {
            await context.WriteIndentationAsync();
            await Identifier.CompileAsync(context);
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