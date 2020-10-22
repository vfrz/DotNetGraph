using System;
using System.Linq;

namespace DotNetGraph.Extensions
{
    internal static class EnumExtensions
    {
        public static string FlagsToString<T>(this T @enum) where T : Enum
        {
            return string.Join(",", Enum.GetValues(typeof(T))
                .Cast<T>()
                .Where(a => @enum.HasFlag(a))
                .Select(a => a.ToString().ToLowerInvariant()));
        }
    }
}
