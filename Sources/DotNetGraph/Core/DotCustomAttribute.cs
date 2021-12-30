using System;

namespace DotNetGraph.Core
{
    public class DotCustomAttribute : IDotAttribute
    {
        public DotCustomAttribute(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Argument name cannot be empty", nameof(name));
            }

            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }

        public override string ToString()
        {
            return $"{Name.ToLowerInvariant()}={Value}";
        }
    }
}
