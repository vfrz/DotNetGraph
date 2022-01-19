using System;
using System.Collections.Generic;
using DotNetGraph.Attributes;

namespace DotNetGraph.Core
{
    public class DotElementWithAttributes : IDotElement
    {
        internal readonly Dictionary<string, IDotAttribute> Attributes;

        public DotElementWithAttributes()
        {
            Attributes = new Dictionary<string, IDotAttribute>();
        }

        public T GetAttribute<T>(string name) where T : IDotAttribute
        {
            if (Attributes.TryGetValue(name, out var attribute))
            {
                if (attribute is T result)
                    return result;
                throw new Exception($"Attribute with name '{name}' doesn't match the expected type (expected: {typeof(T)}, current: {attribute.GetType()})");
            }

            throw new Exception($"There is no attribute named '{name}'");
        }

        public void SetAttribute(string name, IDotAttribute value)
        {
            if (value is null)
                RemoveAttribute(name);
            else
                Attributes[name] = value;
        }

        public void RemoveAttribute(string name)
        {
            Attributes.Remove(name);
        }
    }
}