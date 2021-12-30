using System;
using System.Linq;
using System.Reflection;

namespace DotNetGraph.Extensions
{
    internal static class EnumExtensions
    {
        public static string FlagsToString<T>(this T @enum) where T : Enum
        {
            var type = typeof(T);
            if (type.GetCustomAttribute<FlagsAttribute>() == null)
            {
                throw new InvalidOperationException($"The type '{type}' doesn't have the [Flags] attribute specified.");
            }

            return string.Join(",", Enum.GetValues(type)
                .Cast<T>()
                .Where(a => @enum.HasFlag(a))
                .Select(a => a.ToString().ToLowerInvariant()));
        }
    }
}
