using DotNetGraph.Core;

namespace DotNetGraph.Extensions
{
    public static class DotBaseGraphExtensions
    {
        public static T WithIdentifier<T>(this T graph, string identifier) where T : DotBaseGraph
        {
            graph.Identifier = identifier;
            return graph;
        }

        public static T Add<T>(this T graph, IDotElement element) where T : DotBaseGraph
        {
            graph.Elements.Add(element);
            return graph;
        }
    }
}