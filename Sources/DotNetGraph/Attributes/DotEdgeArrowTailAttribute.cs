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

        public override string ToString()
        {
            return ArrowType.ToString().ToLowerInvariant();
        }
    }
}