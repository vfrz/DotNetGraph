using DotNetGraph.Edge;

namespace DotNetGraph.Attributes
{
    public class DotEdgeStyleAttribute : DotColorAttribute
    {
        public DotEdgeStyle Style { get; set; }

        public DotEdgeStyleAttribute(DotEdgeStyle style = default)
        {
            Style = style;
        }

        public static implicit operator DotEdgeStyleAttribute(DotEdgeStyle? style)
        {
            return style.HasValue ? new DotEdgeStyleAttribute(style.Value) : null;
        }
    }
}
