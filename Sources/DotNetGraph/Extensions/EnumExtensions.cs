using System;
using System.Linq;
using System.Reflection;

namespace DotNetGraph.Extensions
{
    internal static class EnumExtensions
    {
        public static string FlagsToString<T>(this T @enum) where T : Enum
        {
            if (typeof(T).GetCustomAttribute<FlagsAttribute>() is null)
                throw new InvalidOperationException($"The type '{typeof(T)}' doesn't have the [Flags] attribute specified.");

            return string.Join(",", Enum.GetValues(typeof(T))
                .Cast<T>()
                .Where(a => @enum.HasFlag(a))
                .Select(a => a.ToString().ToLowerInvariant()));
        }
    }
}
