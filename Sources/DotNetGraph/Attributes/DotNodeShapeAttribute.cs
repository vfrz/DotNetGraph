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

        public override string ToString()
        {
            return Shape.ToString().ToLowerInvariant();
        }
    }
}