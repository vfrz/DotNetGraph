using DotNetGraph.Compiler;
using DotNetGraph.Node;

namespace DotNetGraph.Extensions
{
    public static class DotGraphExtensions
    {
        public static string Compile(this DotGraph graph, bool applyDefaultStyles = true)
        {
            return new DotCompiler(graph).Compile(applyDefaultStyles);
        }

        public static DotGraph AddNode(this DotGraph graph, string identifier, DotNodeStyleLayout styleLayout = null)
        {
            var node = new DotNode(identifier, styleLayout);
            return graph.AddElement(node);
        }
    }
}