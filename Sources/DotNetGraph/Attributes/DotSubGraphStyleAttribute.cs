using DotNetGraph.Extensions;
using DotNetGraph.SubGraph;

namespace DotNetGraph.Attributes
{
    public class DotSubGraphStyleAttribute : IDotAttribute, ISurroundWithQuotes
    {
        public DotSubGraphStyle Style { get; set; }

        public DotSubGraphStyleAttribute(DotSubGraphStyle style = default)
        {
            Style = style;
        }

        public override string ToString()
        {
            return Style.FlagsToString();
        }
    }
}