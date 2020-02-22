using System.Collections.Generic;
using DotNetGraph.Core;
using DotNetGraph.Node;

namespace DotNetGraph
{
    public class DotGraph : IDotElement
    {
        public IEnumerable<IDotElement> Elements => _elements;
        
        private readonly List<IDotElement> _elements;

        public bool Directed { get; set; }
        
        public string Identifier { get; set; }
        
        public bool Strict { get; set; }
        
        public IDotNodeIdentifierGenerator NodeIdentifierGenerator { get; set; } = new DotGuidNodeIdentifierGenerator();

        public DotGraph()
        {
            _elements = new List<IDotElement>();
        }

        public DotGraph(string identifier, bool directed = false) : this()
        {
            Identifier = identifier;
            Directed = directed;
        }

        public DotGraph Add(IDotElement element)
        {
            if (element is DotNode nodeElement)
            {
                if (string.IsNullOrWhiteSpace(nodeElement.Identifier) && NodeIdentifierGenerator != null)
                {
                    nodeElement.Identifier = NodeIdentifierGenerator.GenerateIdentifier();
                }
            }
            
            _elements.Add(element);

            return this;
        }
    }
}