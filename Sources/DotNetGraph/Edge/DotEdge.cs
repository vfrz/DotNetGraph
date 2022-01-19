using System;
using System.Drawing;
using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Edge
{
    public class DotEdge : DotElementWithAttributes
    {
        private IDotElement _left;
        private IDotElement _right;

        public IDotElement Left
        {
            get => _left;
            set => _left = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IDotElement Right
        {
            get => _right;
            set => _right = value ?? throw new ArgumentNullException(nameof(value));
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

        public DotEdgeStyle Style
        {
            get => GetAttribute<DotEdgeStyleAttribute>("style").Style;
            set => SetAttribute("style", new DotEdgeStyleAttribute(value));
        }

        public string Label
        {
            get => GetAttribute<DotStringAttribute>("label").Value;
            set => SetAttribute("label", new DotStringAttribute(value));
        }

        public float PenWidth
        {
            get => GetAttribute<DotFloatAttribute>("penwidth").Value;
            set => SetAttribute("penwidth", new DotFloatAttribute(value));
        }

        public DotEdgeArrowType ArrowHead
        {
            get => GetAttribute<DotEdgeArrowHeadAttribute>("arrowhead").ArrowType;
            set => SetAttribute("arrowhead", new DotEdgeArrowHeadAttribute(value));
        }

        public DotEdgeArrowType ArrowTail
        {
            get => GetAttribute<DotEdgeArrowHeadAttribute>("arrowtail").ArrowType;
            set => SetAttribute("arrowtail", new DotEdgeArrowHeadAttribute(value));
        }

        public DotPosition Position
        {
            get => GetAttribute<DotPositionAttribute>("pos").Position;
            set => SetAttribute("pos", new DotPositionAttribute(value));
        }

        public DotEdge(IDotElement left, IDotElement right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public DotEdge(string left, string right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            if (string.IsNullOrWhiteSpace(left))
                throw new ArgumentException("Node cannot be empty", nameof(left));

            if (string.IsNullOrWhiteSpace(right))
                throw new ArgumentException("Node cannot be empty", nameof(right));

            Left = new DotString(left);
            Right = new DotString(right);
        }
    }
}