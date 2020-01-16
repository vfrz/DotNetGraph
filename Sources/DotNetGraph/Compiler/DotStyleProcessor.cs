using DotNetGraph.Core;
using DotNetGraph.Node;

namespace DotNetGraph.Compiler
{
    public class DotStyleProcessor
    {
        private readonly DotGraph _graph;

        public DotStyleProcessor(DotGraph graph)
        {
            _graph = graph;
        }

        public void ApplyDefaultLayoutStyles(IElementWithChildren element)
        {
            foreach (var child in element.Elements)
            {
                if (child is DotNode dotNodeChild)
                    dotNodeChild.ApplyStyleLayout(_graph.DefaultNodeStyleLayout);

                if (child is IElementWithChildren childWithChildren)
                    ApplyDefaultLayoutStyles(childWithChildren);
            }
        }
    }
}