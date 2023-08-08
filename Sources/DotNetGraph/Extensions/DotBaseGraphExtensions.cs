using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Extensions
{
    public static class DotBaseGraphExtensions
    {
        public static T WithIdentifier<T>(this T graph, string identifier, bool isHtml = false) where T : DotBaseGraph
        {
            graph.Identifier = new DotIdentifier(identifier, isHtml);
            return graph;
        }

        public static T WithRankDir<T>(this T graph, DotRankDir rankDir) where T : DotBaseGraph
        {
            graph.RankDir = new DotRankDirAttribute(rankDir);
            return graph;
        }

        public static T Add<T>(this T graph, IDotElement element) where T : DotBaseGraph
        {
            graph.Elements.Add(element);
            return graph;
        }
    }
}