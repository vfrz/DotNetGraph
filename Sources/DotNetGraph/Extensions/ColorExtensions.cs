using System.Drawing;

namespace DotNetGraph.Extensions
{
    public static class ColorExtensions
    {
        public static string ToHexString(this Color color)
        {
            if (color.A == 255)
                return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
        }
    }
}