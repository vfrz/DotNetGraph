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
        
        public DotFontColorAttribute FontColor
        {
            get => GetAttribute<DotFontColorAttribute>();
            set => SetAttribute(value);
        }
        
        public DotFillColorAttribute FillColor
        {
            get => GetAttribute<DotFillColorAttribute>();
            set => SetAttribute(value);
        }

        public DotNodeShapeAttribute Shape
        {
            get => GetAttribute<DotNodeShapeAttribute>();
            set => SetAttribute(value);
        }
        
        public DotNodeStyleAttribute Style
        {
            get => GetAttribute<DotNodeStyleAttribute>();
            set => SetAttribute(value);
        }

        public DotLabelAttribute Label
        {
            get => GetAttribute<DotLabelAttribute>();
            set => SetAttribute(value);
        }

        public DotNodeWidthAttribute Width
        {
            get => GetAttribute<DotNodeWidthAttribute>();
            set => SetAttribute(value);
        }

        public DotNodeHeightAttribute Height
        {
            get => GetAttribute<DotNodeHeightAttribute>();
            set => SetAttribute(value);
        }
        
        public DotNode(string identifier = null, DotColorAttribute color = null)
        {
            Identifier = identifier;
            Color = color;
        }
    }
}