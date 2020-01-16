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

        public DotNodeHeightAttribute Height
        {
            get => GetAttribute<DotNodeHeightAttribute>();
            set => SetAttribute(value);
        }
        
        public DotNode(string identifier)
        {
            Identifier = identifier;
        }

        public DotNode(string identifier, DotNodeStyleLayout styleLayout)
        {
            Identifier = identifier;
            ApplyStyleLayout(styleLayout);
        }

        public void ApplyStyleLayout(DotNodeStyleLayout styleLayout)
        {
            if (styleLayout is null)
                return;

            if (styleLayout.Color != null)
                Color = styleLayout.Color;

            if (styleLayout.Height != null)
                Height = styleLayout.Height;

            if (styleLayout.Shape != null)
                Shape = styleLayout.Shape;

            if (styleLayout.Style != null)
                Style = styleLayout.Style;

            if (styleLayout.FillColor != null)
                FillColor = styleLayout.FillColor;

            if (styleLayout.FontColor != null)
                FontColor = styleLayout.FontColor;
        }
    }
}