using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Extensions
{
    public static class DotNodeExtensions
    {
        public static DotNode WithIdentifier(this DotNode node, string identifier, bool isHtml = false)
        {
            node.Identifier = new DotIdentifier(identifier, isHtml);
            return node;
        }

        public static DotNode WithColor(this DotNode node, string color)
        {
            node.Color = new DotColorAttribute(color);
            return node;
        }

        public static DotNode WithColor(this DotNode node, DotColor color)
        {
            node.Color = new DotColorAttribute(color);
            return node;
        }

        public static DotNode WithFillColor(this DotNode node, string color)
        {
            node.FillColor = new DotColorAttribute(color);
            return node;
        }

        public static DotNode WithFillColor(this DotNode node, DotColor color)
        {
            node.FillColor = new DotColorAttribute(color);
            return node;
        }

        public static DotNode WithShape(this DotNode node, string shape)
        {
            node.Shape = new DotNodeShapeAttribute(shape);
            return node;
        }

        public static DotNode WithShape(this DotNode node, DotNodeShape shape)
        {
            node.Shape = new DotNodeShapeAttribute(shape);
            return node;
        }

        public static DotNode WithStyle(this DotNode node, string style)
        {
            node.Style = new DotNodeStyleAttribute(style);
            return node;
        }

        public static DotNode WithStyle(this DotNode node, DotNodeStyle style)
        {
            node.Style = new DotNodeStyleAttribute(style);
            return node;
        }

        public static DotNode WithWidth(this DotNode node, double width)
        {
            node.Width = new DotDoubleAttribute(width);
            return node;
        }

        public static DotNode WithHeight(this DotNode node, double height)
        {
            node.Height = new DotDoubleAttribute(height);
            return node;
        }

        public static DotNode WithPenWidth(this DotNode node, double width)
        {
            node.PenWidth = new DotDoubleAttribute(width);
            return node;
        }

        public static DotNode WithPos(this DotNode node, string value)
        {
            node.Pos = new DotPointAttribute(value);
            return node;
        }

        public static DotNode WithPos(this DotNode node, int x, int y, bool @fixed = false)
        {
            node.Pos = new DotPointAttribute(new DotPoint(x, y, @fixed));
            return node;
        }

        public static DotNode WithPos(this DotNode node, int x, int y, int z, bool @fixed = false)
        {
            node.Pos = new DotPointAttribute(new DotPoint(x, y, z, @fixed));
            return node;
        }
    }
}