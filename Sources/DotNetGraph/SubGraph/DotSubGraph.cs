using System.Collections.Generic;
using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.SubGraph
{
    public class DotSubGraph : DotElementWithAttributes, IElementWithChildren
    {
        public string Identifier { get; set; }
        
        public List<IDotElement> Elements { get; }
        
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

        public DotSubGraph(string identifier = null)
        {
            Elements = new List<IDotElement>();
            Identifier = identifier;
        }
    }
}