using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Node
{
    public class DotNode : IDotElement
    {
        public string Identifier { get; set; }

        public DotColorAttribute Color
        {
            get
            {
                if (_attributes.TryGetValue(nameof(DotColorAttribute), out var colorAttribute))
                    return (DotColorAttribute) colorAttribute;
                return null;
            }
            set
            {
                if (value != null)
                    _attributes[nameof(DotColorAttribute)] = value;
                else if (_attributes.ContainsKey(nameof(DotColorAttribute)))
                    _attributes.Remove(nameof(DotColorAttribute));
            }
        }

        public ReadOnlyCollection<IDotAttribute> Attributes => _attributes.Values.ToList().AsReadOnly();

        private readonly Dictionary<string, IDotAttribute> _attributes;

        public DotNode(string identifier = null, DotColorAttribute color = null)
        {
            _attributes = new Dictionary<string, IDotAttribute>();
            Identifier = identifier;
            Color = color;
        }
    }
}