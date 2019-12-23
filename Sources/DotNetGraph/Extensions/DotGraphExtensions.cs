using DotNetGraph.Compiler;

namespace DotNetGraph.Extensions
{
    public static class DotGraphExtensions
    {
        public static string Compile(this DotGraph graph)
        {
            return new DotCompiler(graph).Compile();
        }
    }
}