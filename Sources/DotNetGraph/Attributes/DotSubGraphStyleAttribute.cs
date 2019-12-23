using DotNetGraph.Core;
using DotNetGraph.SubGraph;

namespace DotNetGraph.Attributes
{
    public class DotSubGraphStyleAttribute : IDotAttribute
    {
        public DotSubGraphStyle Style { get; set; }

        public DotSubGraphStyleAttribute(DotSubGraphStyle style = default)
        {
            Style = style;
        }

        public static implicit operator DotSubGraphStyleAttribute(DotSubGraphStyle? style)
        {
            return style.HasValue ? new DotSubGraphStyleAttribute(style.Value) : null;
        }
    }
}