using DotNetGraph.Core;

namespace DotNetGraph.Extensions
{
    public static class DotGraphExtensions
    {
        public static DotGraph Directed(this DotGraph graph, bool directed = true)
        {
            graph.Directed = directed;
            return graph;
        }
        
        public static DotGraph Strict(this DotGraph graph, bool strict = true)
        {
            graph.Strict = strict;
            return graph;
        }
    }
}