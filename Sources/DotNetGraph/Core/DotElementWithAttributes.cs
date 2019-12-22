using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DotNetGraph.Attributes;

namespace DotNetGraph.Core
{
    public class DotElementWithAttributes : IDotElement
    {
        public ReadOnlyCollection<IDotAttribute> Attributes => _attributes.Values.ToList().AsReadOnly();

        private readonly Dictionary<string, IDotAttribute> _attributes;

        public DotElementWithAttributes(string identifier = null, DotColorAttribute color = null)
        {
            _attributes = new Dictionary<string, IDotAttribute>();
        }

        protected T GetAttribute<T>() where T : IDotAttribute
        {
            if (_attributes.TryGetValue(typeof(T).Name, out var colorAttribute))
                return (T) colorAttribute;
            return default;
        }

        protected void SetAttribute<T>(T value) where T : IDotAttribute
        {
            if (value != null)
                _attributes[nameof(DotColorAttribute)] = value;
            else if (_attributes.ContainsKey(nameof(DotColorAttribute)))
                _attributes.Remove(nameof(DotColorAttribute));
        }
    }
}