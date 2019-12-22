using System.Drawing;

namespace DotNetGraph.Attributes
{
    public class DotFontColorAttribute : DotColorAttribute
    {
        public DotFontColorAttribute(Color color = default) : base(color)
        {
        }

        public static implicit operator DotFontColorAttribute(Color? color)
        {
            return color.HasValue ? new DotFontColorAttribute(color.Value) : null;
        }
    }
}