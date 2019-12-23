using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotNodeHeightAttribute : IDotAttribute
    {
        public float Value { get; set; }

        public DotNodeHeightAttribute(float value = default)
        {
            Value = value;
        }
        
        public static implicit operator DotNodeHeightAttribute(float? value)
        {
            return value.HasValue ? new DotNodeHeightAttribute(value.Value) : null;
        }

        public static implicit operator DotNodeHeightAttribute(int? value)
        {
            return value.HasValue ? new DotNodeHeightAttribute(value.Value) : null;
        }
    }
}