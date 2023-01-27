using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public class DotGraph : DotBaseGraph
    {
        public bool Strict { get; set; } = false;

        public bool Directed { get; set; } = false;

        public override string Compile(CompilationOptions options)
        {
            throw new System.NotImplementedException();
        }
    }
}