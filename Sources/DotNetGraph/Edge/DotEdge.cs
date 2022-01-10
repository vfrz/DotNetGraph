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

        public DotPenWidthAttribute PenWidth
        {
            get => GetAttribute<DotPenWidthAttribute>();
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

        public DotPositionAttribute Position
        {
            get => GetAttribute<DotPositionAttribute>();
            set => SetAttribute(value);
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

        public DotEdge SetCustomAttribute(string name, string value)
        {
            SetCustomAttributeInternal(name, value);

            return this;
        }
    }
}