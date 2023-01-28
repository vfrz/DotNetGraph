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

        public override async Task CompileAsync(CompilationContext context)
        {
            await context.WriteIndentationAsync();
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