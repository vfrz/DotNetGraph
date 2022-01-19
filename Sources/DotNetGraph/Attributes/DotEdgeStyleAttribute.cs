using DotNetGraph.Edge;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotEdgeStyleAttribute : IDotAttribute, ISurroundWithQuotes
    {
        public DotEdgeStyle Style { get; set; }

        public DotEdgeStyleAttribute(DotEdgeStyle style = default)
        {
            Style = style;
        }

        public override string ToString()
        {
            return Style.FlagsToString();
        }
    }
}
