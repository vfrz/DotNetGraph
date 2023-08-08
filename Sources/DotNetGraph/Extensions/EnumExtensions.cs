using System;
using System.Linq;
using System.Reflection;

namespace DotNetGraph.Extensions
{
    public static class EnumExtensions
    {
        public static string FlagsToString<T>(this T enumValue) where T : Enum
        {
            if (typeof(T).GetCustomAttribute<FlagsAttribute>() is null)
                throw new InvalidOperationException($"The type '{typeof(T)}' doesn't have the [Flags] attribute specified.");

            return string.Join(",", Enum.GetValues(typeof(T))
                .Cast<T>()
                .Where(a => enumValue.HasFlag(a))
                .Select(a => a.ToString().ToLowerInvariant()));
        }
    }
}