using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Node
{
    public class DotNode : DotElementWithAttributes
    {
        public string Identifier { get; set; }

        public DotColorAttribute Color
        {
            get => GetAttribute<DotColorAttribute>();
            set => SetAttribute(value);
        }

        public DotNodeShapeAttribute Shape
        {
            get => GetAttribute<DotNodeShapeAttribute>();
            set => SetAttribute(value);
        }
        
        public DotNode(string identifier = null, DotColorAttribute color = null)
        {
            Identifier = identifier;
            Color = color;
        }
    }
}