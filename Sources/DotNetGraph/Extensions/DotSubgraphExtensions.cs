using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Extensions
{
    public static class DotSubgraphExtensions
    {
        public static DotSubgraph WithColor(this DotSubgraph subgraph, string color)
        {
            subgraph.Color = new DotColorAttribute(color);
            return subgraph;
        }

        public static DotSubgraph WithColor(this DotSubgraph subgraph, DotColor color)
        {
            subgraph.Color = new DotColorAttribute(color);
            return subgraph;
        }

        public static DotSubgraph WithStyle(this DotSubgraph subgraph, string style)
        {
            subgraph.Style = new DotSubgraphStyleAttribute(style);
            return subgraph;
        }

        public static DotSubgraph WithStyle(this DotSubgraph subgraph, DotSubgraphStyle style)
        {
            subgraph.Style = new DotSubgraphStyleAttribute(style);
            return subgraph;
        }
    }
}