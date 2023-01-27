using System;
using System.Collections.Generic;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public abstract class DotElementWithAttributes : IDotElement
    {
        private readonly Dictionary<string, IDotAttribute> _attributes = new Dictionary<string, IDotAttribute>();

        public IDotAttribute GetAttribute(string name)
        {
            if (_attributes.TryGetValue(name, out var attribute))
                return attribute;
            throw new Exception($"There is no attribute named '{name}'");
        }

        public T GetAttribute<T>(string name) where T : IDotAttribute
        {
            var attribute = GetAttribute(name);
            if (attribute is T result)
                return result;
            throw new Exception($"Attribute with name '{name}' doesn't match the expected type (expected: {typeof(T)}, current: {attribute.GetType()})");
        }

        public bool TryGetAttribute(string name, out IDotAttribute attribute)
        {
            var result = _attributes.TryGetValue(name, out var outAttribute);
            if (result)
            {
                attribute = outAttribute;
                return true;
            }

            attribute = default;
            return false;
        }

        public bool TryGetAttribute<T>(string name, out T attribute) where T : IDotAttribute
        {
            var result = TryGetAttribute(name, out var untypedAttribute);
            if (result is false)
            {
                attribute = default;
                return false;
            }

            if (untypedAttribute is T typedAttribute)
            {
                attribute = typedAttribute;
                return true;
            }

            throw new Exception($"Attribute with name '{name}' doesn't match the expected type (expected: {typeof(T)}, current: {untypedAttribute.GetType()})");
        }

        public void SetAttribute(string name, IDotAttribute value)
        {
            if (value is null)
                RemoveAttribute(name);
            else
                _attributes[name] = value;
        }

        public bool RemoveAttribute(string name)
        {
            return _attributes.Remove(name);
        }

        public abstract string Compile(CompilationOptions options);
    }
}