using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public abstract class DotBaseGraph : DotElement
    {
        public DotIdentifier Identifier { get; set; }

        public List<IDotElement> Elements { get; } = new List<IDotElement>();

        public abstract override Task CompileAsync(CompilationContext context);
    }
}