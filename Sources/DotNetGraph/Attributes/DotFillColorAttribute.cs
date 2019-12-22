using System.Drawing;

namespace DotNetGraph.Attributes
{
    public class DotFillColorAttribute : DotColorAttribute
    {
        public DotFillColorAttribute(Color color = default) : base(color)
        {
        }

        public static implicit operator DotFillColorAttribute(Color? color)
        {
            return color.HasValue ? new DotFillColorAttribute(color.Value) : null;
        }
    }
}