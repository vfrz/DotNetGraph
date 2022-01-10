using DotNetGraph.Attributes;
using DotNetGraph.Core;
using System;

namespace DotNetGraph.Node
{
    public class DotNode : DotElementWithAttributes
    {
        private string _identifier;

        public string Identifier
        {
            get => _identifier;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Identifier cannot be empty", nameof(value));

                _identifier = value;
            }
        }

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

        public DotPenWidthAttribute PenWidth
        {
            get => GetAttribute<DotPenWidthAttribute>();
            set => SetAttribute(value);
        }

        public DotNodeHeightAttribute Height
        {
            get => GetAttribute<DotNodeHeightAttribute>();
            set => SetAttribute(value);
        }

        public DotPositionAttribute Position
        {
            get => GetAttribute<DotPositionAttribute>();
            set => SetAttribute(value);
        }

        public DotNode(string identifier, DotColorAttribute color = null)
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));

            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("Identifier cannot be empty", nameof(identifier));

            Identifier = identifier;
            Color = color;
        }

        public DotNode SetCustomAttribute(string name, string value)
        {
            SetCustomAttributeInternal(name, value);

            return this;
        }
    }
}