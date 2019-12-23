using DotNetGraph.Core;
using DotNetGraph.Edge;

namespace DotNetGraph.Attributes
{
    public class DotEdgeArrowHeadAttribute : IDotAttribute
    {
        public DotEdgeArrowType ArrowType { get; set; }

        public DotEdgeArrowHeadAttribute(DotEdgeArrowType arrowType = default)
        {
            ArrowType = arrowType;
        }

        public static implicit operator DotEdgeArrowHeadAttribute(DotEdgeArrowType? arrowType)
        {
            return arrowType.HasValue ? new DotEdgeArrowHeadAttribute(arrowType.Value) : null;
        }
    }
}