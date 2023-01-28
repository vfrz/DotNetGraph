using System.Drawing;
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
        
        public static DotNode WithColor(this DotNode node, Color color)
        {
            node.Color = new DotColorAttribute(color);
            return node;
        }
        
        public static DotNode WithFillColor(this DotNode node, string color)
        {
            node.FillColor = new DotColorAttribute(color);
            return node;
        }
        
        public static DotNode WithFillColor(this DotNode node, Color color)
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
    }
}