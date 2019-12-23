using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;

namespace DotNetGraph.Compiler
{
    public class DotCompiler
    {
        private readonly DotGraph _graph;

        public DotCompiler(DotGraph graph)
        {
            _graph = graph;
        }
        
        public string Compile()
        {
            var builder = new StringBuilder();

            CompileGraph(builder);

            return builder.ToString();
        }

        private void CompileGraph(StringBuilder builder)
        {
            if (_graph.Strict)
                builder.Append("strict ");

            builder.Append(_graph.Directed ? "digraph " : "graph ");

            builder.Append($"{_graph.Identifier} {{ ");

            foreach (var element in _graph.Elements)
            {
                if (element is DotEdge edge)
                {
                    CompileEdge(builder, edge);
                }
                else if (element is DotNode node)
                {
                    CompileNode(builder, node);
                }
                else
                {
                    throw new DotException($"Graph body can't contain element of type: {element.GetType()}");
                }
            }

            builder.Append("}");
        }

        private void CompileEdge(StringBuilder builder, DotEdge edge)
        {
            CompileEdgeEndPoint(builder, edge.Left);

            builder.Append(_graph.Directed ? " -> " : " -- ");

            CompileEdgeEndPoint(builder, edge.Right);
            
            CompileAttributes(builder, edge.Attributes);
            
            builder.Append("; ");
        }

        private void CompileEdgeEndPoint(StringBuilder builder, IDotElement endPoint)
        {
            if (endPoint is DotString leftEdgeString)
            {
                builder.Append($"{leftEdgeString.Value}");
            }
            else if (endPoint is DotNode leftEdgeNode)
            {
                builder.Append($"{leftEdgeNode.Identifier}");
            }
            else
            {
                throw new DotException($"Endpoint of an edge can't be of type: {endPoint.GetType()}");
            }
        }

        private void CompileNode(StringBuilder builder, DotNode node)
        {
            builder.Append($"{node.Identifier} ");

            CompileAttributes(builder, node.Attributes);
            
            builder.Append("; ");
        }

        private void CompileAttributes(StringBuilder builder, ReadOnlyCollection<IDotAttribute> attributes)
        {
            if (attributes.Count == 0)
                return;

            builder.Append("[");

            var attributeValues = new List<string>();
            
            foreach (var attribute in attributes)
            {
                if (attribute is DotNodeShapeAttribute nodeShapeAttribute)
                {
                    attributeValues.Add($"shape={nodeShapeAttribute.Shape.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotNodeStyleAttribute nodeStyleAttribute)
                {
                    attributeValues.Add($"style={nodeStyleAttribute.Style.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotFontColorAttribute fontColorAttribute)
                {
                    attributeValues.Add($"fontcolor=\"{fontColorAttribute.ToHex()}\"");
                }
                else if (attribute is DotFillColorAttribute fillColorAttribute)
                {
                    attributeValues.Add($"fillcolor=\"{fillColorAttribute.ToHex()}\"");
                }
                else if (attribute is DotColorAttribute colorAttribute)
                {
                    attributeValues.Add($"color=\"{colorAttribute.ToHex()}\"");
                }
                else if (attribute is DotLabelAttribute labelAttribute)
                {
                    var text = FormatString(labelAttribute.Text);
                    attributeValues.Add($"label=\"{text}\"");
                }
                else if (attribute is DotNodeHeightAttribute nodeHeightAttribute)
                {
                    attributeValues.Add($"height={nodeHeightAttribute.Value:F2}");
                }
                else if (attribute is DotEdgeArrowTailAttribute edgeArrowTailAttribute)
                {
                    attributeValues.Add($"arrowtail={edgeArrowTailAttribute.ArrowType.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotEdgeArrowHeadAttribute edgeArrowHeadAttribute)
                {
                    attributeValues.Add($"arrowhead={edgeArrowHeadAttribute.ArrowType.ToString().ToLowerInvariant()}");
                }
                else
                {
                    throw new DotException($"Attribute type not supported: {attribute.GetType()}");
                }
            }

            builder.Append(string.Join(",", attributeValues));
            
            builder.Append("]");
        }

        private static string FormatString(string value)
        {
            var result = value.Replace("\"", "\\\"");

            return result;
        }
    }
}