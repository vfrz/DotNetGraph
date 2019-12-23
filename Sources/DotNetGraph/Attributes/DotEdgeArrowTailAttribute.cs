using DotNetGraph.Core;
using DotNetGraph.Edge;

namespace DotNetGraph.Attributes
{
    public class DotEdgeArrowTailAttribute : IDotAttribute
    {
        public DotEdgeArrowType ArrowType { get; set; }

        public DotEdgeArrowTailAttribute(DotEdgeArrowType arrowType = default)
        {
            ArrowType = arrowType;
        }

        public static implicit operator DotEdgeArrowTailAttribute(DotEdgeArrowType? arrowType)
        {
            return arrowType.HasValue ? new DotEdgeArrowTailAttribute(arrowType.Value) : null;
        }
    }
}