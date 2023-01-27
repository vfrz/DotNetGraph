using System.Collections.Generic;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public abstract class DotBaseGraph : DotElementWithAttributes
    {
        public string Identifier { get; set; }

        public List<IDotElement> Elements { get; } = new List<IDotElement>();

        public abstract override string Compile(CompilationOptions options);
    }
}