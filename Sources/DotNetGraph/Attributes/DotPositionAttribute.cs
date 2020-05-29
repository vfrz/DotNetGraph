using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotPositionAttribute : IDotAttribute
    {
        public DotPosition Position { get; set; }
        
        public DotPositionAttribute(DotPosition position = default)
        {
            Position = position;
        }
        
        public static implicit operator DotPositionAttribute(DotPosition position)
        {
            return new DotPositionAttribute(position);
        }
    }
}