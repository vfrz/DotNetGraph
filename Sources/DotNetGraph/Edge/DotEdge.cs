using System.Drawing;
using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Edge
{
    public class DotEdge : DotElementWithAttributes
    {
        public IDotElement Left { get; set; }
        
        public IDotElement Right { get; set; }

        public DotColorAttribute Color
        {
            get => GetAttribute<DotColorAttribute>();
            set => SetAttribute(value);
        }
        
        public DotFontColorAttribute FontColor
        {
            get => GetAttribute<DotFontColorAttribute>();
            set => SetAttribute(value);
        }

        public DotEdgeStyleAttribute Style
        {
            get => GetAttribute<DotEdgeStyleAttribute>();
            set => SetAttribute(value);
        }

        public DotLabelAttribute Label
        {
            get => GetAttribute<DotLabelAttribute>();
            set => SetAttribute(value);
        }
        
        public DotEdgeArrowHeadAttribute ArrowHead
        {
            get => GetAttribute<DotEdgeArrowHeadAttribute>();
            set => SetAttribute(value);
        }
        
        public DotEdgeArrowTailAttribute ArrowTail
        {
            get => GetAttribute<DotEdgeArrowTailAttribute>();
            set => SetAttribute(value);
        }
        
        public DotEdge()
        {
        }
        
        public DotEdge(IDotElement left, IDotElement right)
        {
            Left = left;
            Right = right;
        }

        public DotEdge(string left, string right)
        {
            Left = new DotString(left);
            Right = new DotString(right);
        }
    }
}