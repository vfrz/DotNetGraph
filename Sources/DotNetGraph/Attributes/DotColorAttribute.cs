using System.Drawing;
using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotColorAttribute : IDotAttribute
    {
        public Color Color { get; set; }

        public DotColorAttribute(Color color = default)
        {
            Color = color;
        }

        public static implicit operator DotColorAttribute(Color? color)
        {
            return color.HasValue ? new DotColorAttribute(color.Value) : null;
        }
    }
}