using DotNetGraph.Core;
using DotNetGraph.Node;

namespace DotNetGraph.Attributes
{
    public class DotNodeShapeAttribute : IDotAttribute
    {
        public DotNodeShape Shape { get; set; }

        public DotNodeShapeAttribute(DotNodeShape shape = default)
        {
            Shape = shape;
        }

        public static implicit operator DotNodeShapeAttribute(DotNodeShape? shape)
        {
            return shape.HasValue ? new DotNodeShapeAttribute(shape.Value) : null;
        }
    }
}