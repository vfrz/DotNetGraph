using System.Drawing;
using DotNetGraph.Extensions;

namespace DotNetGraph.Attributes
{
    public class DotColorAttribute : IDotAttribute, ISurroundWithQuotes
    {
        public Color Color { get; set; }

        public DotColorAttribute(Color color = default)
        {
            Color = color;
        }

        public override string ToString()
        {
            return Color.ToHex();
        }
    }
}