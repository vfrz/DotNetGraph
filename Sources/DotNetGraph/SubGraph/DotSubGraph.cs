using System.Collections.Generic;
using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.SubGraph
{
    public class DotSubGraph : DotElementWithAttributes, IDotGraph
    {
        public string Identifier { get; set; }

        public DotColorAttribute Color
        {
            get => GetAttribute<DotColorAttribute>();
            set => SetAttribute(value);
        }

        public DotSubGraphStyleAttribute Style
        {
            get => GetAttribute<DotSubGraphStyleAttribute>();
            set => SetAttribute(value);
        }

        public DotLabelAttribute Label
        {
            get => GetAttribute<DotLabelAttribute>();
            set => SetAttribute(value);
        }

        public List<IDotElement> Elements { get; }

        public DotSubGraph(string identifier = null)
        {
            Elements = new List<IDotElement>();
            Identifier = identifier;
        }

        public DotSubGraph SetCustomAttribute(string name, string value)
        {
            SetCustomAttributeInternal(name, value);

            return this;
        }
    }
}