using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Extensions
{
    public static class DotEdgeExtensions
    {
        public static DotEdge From(this DotEdge edge, string from, bool isHtml = false)
        {
            edge.From = new DotIdentifier(from, isHtml);
            return edge;
        }
        
        public static DotEdge From(this DotEdge edge, DotNode from)
        {
            edge.From = from.Identifier;
            return edge;
        }
        
        public static DotEdge To(this DotEdge edge, string to, bool isHtml = false)
        {
            edge.To = new DotIdentifier(to, isHtml);
            return edge;
        }
        
        public static DotEdge To(this DotEdge edge, DotNode to)
        {
            edge.To = to.Identifier;
            return edge;
        }
        
        public static DotEdge WithColor(this DotEdge edge, string color)
        {
            edge.Color = new DotColorAttribute(color);
            return edge;
        }

        public static DotEdge WithColor(this DotEdge edge, DotColor color)
        {
            edge.Color = new DotColorAttribute(color);
            return edge;
        }
        
        public static DotEdge WithStyle(this DotEdge edge, string style)
        {
            edge.Style = new DotEdgeStyleAttribute(style);
            return edge;
        }

        public static DotEdge WithStyle(this DotEdge edge, DotEdgeStyle style)
        {
            edge.Style = new DotEdgeStyleAttribute(style);
            return edge;
        }
        
        public static DotEdge WithPenWidth(this DotEdge edge, double width)
        {
            edge.PenWidth = new DotDoubleAttribute(width);
            return edge;
        }
        
        public static DotEdge WithArrowHead(this DotEdge edge, string arrowType)
        {
            edge.ArrowHead = new DotEdgeArrowTypeAttribute(arrowType);
            return edge;
        }

        public static DotEdge WithArrowHead(this DotEdge edge, DotEdgeArrowType arrowType)
        {
            edge.ArrowHead = new DotEdgeArrowTypeAttribute(arrowType);
            return edge;
        }
        
        public static DotEdge WithArrowTail(this DotEdge edge, string arrowType)
        {
            edge.ArrowTail = new DotEdgeArrowTypeAttribute(arrowType);
            return edge;
        }

        public static DotEdge WithArrowTail(this DotEdge edge, DotEdgeArrowType arrowType)
        {
            edge.ArrowTail = new DotEdgeArrowTypeAttribute(arrowType);
            return edge;
        }
        
        public static DotEdge WithPos(this DotEdge edge, string value)
        {
            edge.Pos = new DotPointAttribute(value);
            return edge;
        }

        public static DotEdge WithPos(this DotEdge edge, int x, int y, bool @fixed = false)
        {
            edge.Pos = new DotPointAttribute(new DotPoint(x, y, @fixed));
            return edge;
        }

        public static DotEdge WithPos(this DotEdge edge, int x, int y, int z, bool @fixed = false)
        {
            edge.Pos = new DotPointAttribute(new DotPoint(x, y, z, @fixed));
            return edge;
        }
    }
}