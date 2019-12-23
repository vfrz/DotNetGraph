using DotNetGraph.Core;
using DotNetGraph.Node;

namespace DotNetGraph.Attributes
{
    public class DotNodeStyleAttribute : DotColorAttribute
    {
        public DotNodeStyle Style { get; set; }

        public DotNodeStyleAttribute(DotNodeStyle style = default)
        {
            Style = style;
        }

        public static implicit operator DotNodeStyleAttribute(DotNodeStyle? style)
        {
            return style.HasValue ? new DotNodeStyleAttribute(style.Value) : null;
        }
    }
}