using System.Collections.Generic;
using DotNetGraph.Core;
using DotNetGraph.Node;

namespace DotNetGraph
{
    public class DotGraph : IDotElement, IElementWithChildren
    {
        public bool Directed { get; set; }
        
        public string Identifier { get; set; }
        
        public bool Strict { get; set; }
        
        public List<IDotElement> Elements { get; }
        
        public DotNodeStyleLayout DefaultNodeStyleLayout { get; set; }

        public DotGraph(string identifier, bool directed = false)
        {
            Elements = new List<IDotElement>();
            Identifier = identifier;
            Directed = directed;
        }

        public DotGraph AddElement(IDotElement element)
        {
            Elements.Add(element);
            return this;
        }

        public DotGraph WithDefaultNodeStyleLayout(DotNodeStyleLayout nodeStyleLayout)
        {
            DefaultNodeStyleLayout = nodeStyleLayout;
            return this;
        }
    }
}