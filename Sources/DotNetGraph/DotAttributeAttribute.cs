using System;

namespace DotNetGraph
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DotAttributeAttribute : Attribute
    {
        public string Name { get; }

        public object DefaultValue { get; }

        public DotAttributeAttribute(string name, object defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }
    }
}