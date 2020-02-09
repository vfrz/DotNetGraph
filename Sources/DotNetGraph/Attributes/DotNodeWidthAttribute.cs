using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotNodeWidthAttribute : IDotAttribute
    {
        public float Value { get; set; }

        public DotNodeWidthAttribute(float value = default)
        {
            Value = value;
        }
        
        public static implicit operator DotNodeWidthAttribute(float? value)
        {
            return value.HasValue ? new DotNodeWidthAttribute(value.Value) : null;
        }

        public static implicit operator DotNodeWidthAttribute(int? value)
        {
            return value.HasValue ? new DotNodeWidthAttribute(value.Value) : null;
        }
    }
}