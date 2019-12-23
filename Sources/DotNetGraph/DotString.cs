using DotNetGraph.Core;

namespace DotNetGraph
{
    public class DotString : IDotElement
    {
        public string Value { get; set; }

        public DotString(string value = null)
        {
            Value = value;
        }
    }
}