using System.Collections.Generic;
using DotNetGraph.Core;

namespace DotNetGraph
{
    public class DotGraph : IDotElement, IDotGraph
    {
        public bool Directed { get; set; }

        public string Identifier { get; set; }

        public bool Strict { get; set; }

        public List<IDotElement> Elements { get; }

        public DotGraph()
        {
            Elements = new List<IDotElement>();
        }

        public DotGraph(string identifier, bool directed = false) : this()
        {
            Identifier = identifier;
            Directed = directed;
        }
    }
}