using DotNetGraph.Attributes;
using DotNetGraph.Core;
using System;
using System.Drawing;

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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Identifier cannot be null or empty", nameof(value));
                _identifier = value;
            }
        }

        public Color Color
        {
            get => GetAttribute<DotColorAttribute>("color").Color;
            set => SetAttribute("color", new DotColorAttribute(value));
        }

        public Color FontColor
        {
            get => GetAttribute<DotColorAttribute>("fontcolor").Color;
            set => SetAttribute("fontcolor", new DotColorAttribute(value));
        }

        public Color FillColor
        {
            get => GetAttribute<DotColorAttribute>("fillcolor").Color;
            set => SetAttribute("fillcolor", new DotColorAttribute(value));
        }

        public DotNodeShape Shape
        {
            get => GetAttribute<DotNodeShapeAttribute>("shape").Shape;
            set => SetAttribute("shape", new DotNodeShapeAttribute(value));
        }

        public DotNodeStyle Style
        {
            get => GetAttribute<DotNodeStyleAttribute>("style").Style;
            set => SetAttribute("style", new DotNodeStyleAttribute(value));
        }

        public string Label
        {
            get => GetAttribute<DotStringAttribute>("label").Value;
            set => SetAttribute("label", new DotStringAttribute(value));
        }

        public float Width
        {
            get => GetAttribute<DotFloatAttribute>("width").Value;
            set => SetAttribute("width", new DotFloatAttribute(value));
        }

        public float Height
        {
            get => GetAttribute<DotFloatAttribute>("height").Value;
            set => SetAttribute("height", new DotFloatAttribute(value));
        }

        public float PenWidth
        {
            get => GetAttribute<DotFloatAttribute>("penwidth").Value;
            set => SetAttribute("penwidth", new DotFloatAttribute(value));
        }

        public DotPosition Position
        {
            get => GetAttribute<DotPositionAttribute>("pos").Position;
            set => SetAttribute("pos", new DotPositionAttribute(value));
        }

        public DotNode(string identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));

            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("Identifier cannot be empty", nameof(identifier));

            Identifier = identifier;
        }
    }
}