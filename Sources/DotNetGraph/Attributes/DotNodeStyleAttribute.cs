using DotNetGraph.Extensions;
using DotNetGraph.Node;

namespace DotNetGraph.Attributes
{
    public class DotNodeStyleAttribute : IDotAttribute, ISurroundWithQuotes
    {
        public DotNodeStyle Style { get; set; }

        public DotNodeStyleAttribute(DotNodeStyle style = default)
        {
            Style = style;
        }

        public override string ToString()
        {
            return Style.FlagsToString();
        }
    }
}