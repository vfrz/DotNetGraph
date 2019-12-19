using DotNetGraph.Core;

namespace DotNetGraph.Edge
{
    public class DotEdge : IDotElement
    {
        public IDotElement Left { get; set; }
        
        public IDotElement Right { get; set; }

        public DotEdge()
        {
        }
        
        public DotEdge(IDotElement left, IDotElement right)
        {
            Left = left;
            Right = right;
        }

        public DotEdge(string left, string right)
        {
            Left = new DotString(left);
            Right = new DotString(right);
        }
    }
}