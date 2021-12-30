using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DotNetGraph.Attributes;

namespace DotNetGraph.Core
{
    public class DotElementWithAttributes : IDotElement
    {
        public ReadOnlyCollection<IDotAttribute> Attributes => _attributes.Values
            .Concat(_customAttributes.Values)
            .ToList()
            .AsReadOnly();

        private readonly Dictionary<string, IDotAttribute> _attributes;
        private readonly Dictionary<string, DotCustomAttribute> _customAttributes = new Dictionary<string, DotCustomAttribute>(StringComparer.OrdinalIgnoreCase);

        public DotElementWithAttributes(string identifier = null, DotColorAttribute color = null)
        {
            _attributes = new Dictionary<string, IDotAttribute>();
        }

        protected T GetAttribute<T>() where T : IDotAttribute
        {
            if (_attributes.TryGetValue(typeof(T).Name, out var colorAttribute))
                return (T)colorAttribute;
            return default;
        }

        protected void SetAttribute<T>(T value) where T : IDotAttribute
        {
            if (value != null)
                _attributes[typeof(T).Name] = value;
            else if (_attributes.ContainsKey(typeof(T).Name))
                _attributes.Remove(typeof(T).Name);
        }

        public DotElementWithAttributes SetCustomAttribute(string name, string value)
        {
            var attr = new DotCustomAttribute(name, value);
            _customAttributes[name] = attr;

            return this;
        }
    }
}