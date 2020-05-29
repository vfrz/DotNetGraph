using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using DotNetGraph.Attributes;
using DotNetGraph.Core;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;

namespace DotNetGraph.Compiler
{
    public class DotCompiler
    {
        private readonly DotGraph _graph;

        public DotCompiler(DotGraph graph)
        {
            _graph = graph;
        }
        
        public string Compile(bool indented = false)
        {
            var builder = new StringBuilder();

            CompileGraph(builder, indented);

            return builder.ToString();
        }

        private void CompileGraph(StringBuilder builder, bool indented)
        {
            var indentationLevel = 0;
            
            if (_graph.Strict)
                builder.Append("strict ");

            builder.Append(_graph.Directed ? "digraph " : "graph ");

            builder.Append($"\"{FormatString(_graph.Identifier)}\" {{ ");

            builder.AddIndentationNewLine(indented);
            
            indentationLevel++;
            
            foreach (var element in _graph.Elements)
            {
                if (element is DotEdge edge)
                {
                    CompileEdge(builder, edge, indented, indentationLevel);
                }
                else if (element is DotNode node)
                {
                    CompileNode(builder, node, indented, indentationLevel);
                }
                else if (element is DotSubGraph subGraph)
                {
                    CompileSubGraph(builder, subGraph, indented, indentationLevel);
                }
                else
                {
                    throw new DotException($"Graph body can't contain element of type: {element.GetType()}");
                }
            }

            indentationLevel--;
            
            builder.Append("}");
        }

        private void CompileSubGraph(StringBuilder builder, DotSubGraph subGraph, bool indented, int indentationLevel)
        {
            builder.AddIndentation(indented, indentationLevel);
            
            builder.Append($"subgraph \"{FormatString(subGraph.Identifier)}\" {{ ");

            builder.AddIndentationNewLine(indented);

            indentationLevel++;
            
            CompileSubGraphAttributes(builder, subGraph.Attributes);
            
            foreach (var element in subGraph.Elements)
            {
                if (element is DotEdge edge)
                {
                    CompileEdge(builder, edge, indented, indentationLevel);
                }
                else if (element is DotNode node)
                {
                    CompileNode(builder, node, indented, indentationLevel);
                }
                else if (element is DotSubGraph subSubGraph)
                {
                    CompileSubGraph(builder, subSubGraph, indented, indentationLevel);
                }
                else
                {
                    throw new DotException($"Subgraph body can't contain element of type: {element.GetType()}");
                }
            }

            indentationLevel--;
            
            builder.AddIndentation(indented, indentationLevel);
            
            builder.Append("} ");

            builder.AddIndentationNewLine(indented);
        }

        private void CompileSubGraphAttributes(StringBuilder builder, ReadOnlyCollection<IDotAttribute> attributes)
        {
            if (attributes.Count == 0)
                return;
            
            foreach (var attribute in attributes)
            {
                if (attribute is DotSubGraphStyleAttribute subGraphStyleAttribute)
                {
                    builder.Append($"style={subGraphStyleAttribute.Style.ToString().ToLowerInvariant()}; ");
                }
                else if (attribute is DotColorAttribute colorAttribute)
                {
                    builder.Append($"color=\"{colorAttribute.ToHex()}\"; ");
                }
                else if (attribute is DotLabelAttribute labelAttribute)
                {
                    builder.Append($"label=\"{FormatString(labelAttribute.Text)}\"; ");
                }
                else
                {
                    throw new DotException($"Attribute type not supported: {attribute.GetType()}");
                }
            }
        }

        private void CompileEdge(StringBuilder builder, DotEdge edge, bool indented, int indentationLevel)
        {
            builder.AddIndentation(indented, indentationLevel);
            
            CompileEdgeEndPoint(builder, edge.Left);

            builder.Append(_graph.Directed ? " -> " : " -- ");

            CompileEdgeEndPoint(builder, edge.Right);
            
            CompileAttributes(builder, edge.Attributes);
            
            builder.Append("; ");

            builder.AddIndentationNewLine(indented);
        }

        private void CompileEdgeEndPoint(StringBuilder builder, IDotElement endPoint)
        {
            if (endPoint is DotString leftEdgeString)
            {
                builder.Append($"\"{FormatString(leftEdgeString.Value)}\"");
            }
            else if (endPoint is DotNode leftEdgeNode)
            {
                builder.Append($"\"{FormatString(leftEdgeNode.Identifier)}\"");
            }
            else
            {
                throw new DotException($"Endpoint of an edge can't be of type: {endPoint.GetType()}");
            }
        }

        private void CompileNode(StringBuilder builder, DotNode node, bool indented, int indentationLevel)
        {
            builder.AddIndentation(indented, indentationLevel);
            
            builder.Append($"\"{FormatString(node.Identifier)}\"");

            CompileAttributes(builder, node.Attributes);
            
            builder.Append("; ");

            builder.AddIndentationNewLine(indented);
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
                else if (attribute is DotEdgeStyleAttribute edgeStyleAttribute)
                {
                    attributeValues.Add($"style={edgeStyleAttribute.Style.ToString().ToLowerInvariant()}");
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
                    attributeValues.Add($"label=\"{FormatString(labelAttribute.Text)}\"");
                }
                else if (attribute is DotNodeWidthAttribute nodeWidthAttribute)
                {
                    attributeValues.Add(string.Format(CultureInfo.InvariantCulture, "width={0:F2}", nodeWidthAttribute.Value));
                }
                else if (attribute is DotNodeHeightAttribute nodeHeightAttribute)
                {
                    attributeValues.Add(string.Format(CultureInfo.InvariantCulture, "height={0:F2}", nodeHeightAttribute.Value));
                }
                else if (attribute is DotPenWidthAttribute dotPenwidthAttribute)
                {
                    attributeValues.Add(string.Format(CultureInfo.InvariantCulture, "penwidth={0:F2}", dotPenwidthAttribute.Value));
                }
                else if (attribute is DotEdgeArrowTailAttribute edgeArrowTailAttribute)
                {
                    attributeValues.Add($"arrowtail={edgeArrowTailAttribute.ArrowType.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotEdgeArrowHeadAttribute edgeArrowHeadAttribute)
                {
                    attributeValues.Add($"arrowhead={edgeArrowHeadAttribute.ArrowType.ToString().ToLowerInvariant()}");
                }
                else if (attribute is DotPositionAttribute positionAttribute && positionAttribute.Position != null)
                {
                    attributeValues.Add($"pos=\"{positionAttribute.Position.X},{positionAttribute.Position.Y}!\"");
                }
                else
                {
                    throw new DotException($"Attribute type not supported: {attribute.GetType()}");
                }
            }

            builder.Append(string.Join(",", attributeValues));
            
            builder.Append("]");
        }

        internal static string FormatString(string value)
        {
            var result = value
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r\n", "\\n")
                .Replace("\n", "\\n");

            return result;
        }
    }
}