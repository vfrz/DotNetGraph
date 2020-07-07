using DotNetGraph.Compiler;

namespace DotNetGraph.Extensions
{
    public static class DotGraphExtensions
    {
        public static string Compile(this DotGraph graph, bool indented = false, bool formatStrings = true)
        {
            return new DotCompiler(graph).Compile(indented, formatStrings);
        }
    }
}