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

        public override string ToString()
        {
            return ArrowType.ToString().ToLowerInvariant();
        }
    }
}