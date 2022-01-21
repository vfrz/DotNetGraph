using System.Collections.Generic;
using System.Drawing;
using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.SubGraph
{
    public class DotSubGraph : DotElementWithAttributes, IDotGraph
    {
        public string Identifier { get; set; }

        public Color Color
        {
            get => GetAttribute<DotColorAttribute>("color").Color;
            set => SetAttribute("color", new DotColorAttribute(value));
        }

        public DotSubGraphStyle Style
        {
            get => GetAttribute<DotSubGraphStyleAttribute>("style").Style;
            set => SetAttribute("style", new DotSubGraphStyleAttribute(value));
        }

        public string Label
        {
            get => GetAttribute<DotStringAttribute>("label").Value;
            set => SetAttribute("label", new DotStringAttribute(value));
        }

        public List<IDotElement> Elements { get; } = new List<IDotElement>();

        public DotSubGraph(string identifier = null)
        {
            Identifier = identifier;
        }

        public DotSubGraph WithColor(Color color)
        {
            Color = color;
            return this;
        }

        public DotSubGraph WithStyle(DotSubGraphStyle style)
        {
            Style = style;
            return this;
        }

        public DotSubGraph WithLabel(string label)
        {
            Label = label;
            return this;
        }
    }
}