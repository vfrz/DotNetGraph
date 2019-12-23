using DotNetGraph.Attributes;

namespace DotNetGraph.Extensions
{
    public static class DotColorExtensions
    {
        public static string ToHex(this DotColorAttribute colorAttribute)
        {
            return $"#{colorAttribute.Color.R:X2}{colorAttribute.Color.G:X2}{colorAttribute.Color.B:X2}";
        }
    }
}