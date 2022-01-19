using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotPositionAttribute : IDotAttribute, ISurroundWithQuotes
    {
        public DotPosition Position { get; set; }

        public DotPositionAttribute(DotPosition position = default)
        {
            Position = position;
        }

        public override string ToString()
        {
            var result = $"{Position.X},{Position.Y}";
            if (Position.Fixed)
                result += "!";
            return result;
        }
    }
}