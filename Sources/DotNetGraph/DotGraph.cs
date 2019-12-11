using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DotNetGraph
{
    public class DotGraph
    {
        public string Name { get; }

        public bool Directed { get; }

        private List<DotElement> _elements;

        public DotGraph(string name, bool directed = false)
        {
            Name = name;
            Directed = directed;
            _elements = new List<DotElement>();
        }

        public string Compile(bool minified = true)
        {
            var builder = new StringBuilder();

            builder.Append((Directed ? "di" : "") + $"graph {Name} {{" + (minified ? "" : "\n"));

            foreach (var element in _elements)
            {
                if (element is DotNode node)
                    builder.Append((minified ? "" : "\t") + node.Name + " [ ");
                else if (element is DotArrow arrow)
                    if (Directed)
                        builder.Append((minified ? "" : "\t") + arrow.StartNodeName + "->" + arrow.TargetNodeName + " [ ");
                    else
                        builder.Append((minified ? "" : "\t") + arrow.StartNodeName + "--" + arrow.TargetNodeName + " [ ");

                foreach (var p in element.GetType().GetProperties())
                {
                    if (p.CanRead && Attribute.IsDefined(p, typeof(DotAttributeAttribute)))
                    {
                        var attribute = p.GetCustomAttributes(typeof(DotAttributeAttribute), false)
                            .Cast<DotAttributeAttribute>()
                            .FirstOrDefault();

                        var value = p.GetValue(element);

                        if (value.Equals(attribute?.DefaultValue))
                            continue;

                        var isEnum = value.GetType().IsEnum;
                        var isString = value is string;
                        var isFloat = value is float;

                        var valueString = isEnum ? value.ToString().ToLower() : (isFloat ? Convert.ToSingle(value).ToString(CultureInfo.InvariantCulture) : value);

                        builder.Append(attribute?.Name + "=" + (isString ? "\"" : "") + valueString + (isString ? "\" " : " "));
                    }
                }

                builder.Append("];" + (minified ? "" : "\n"));
            }

            builder.Append("}");

            return builder.ToString();
        }

        public void Add(DotElement element)
        {
            _elements.Add(element);
        }
    }
}
