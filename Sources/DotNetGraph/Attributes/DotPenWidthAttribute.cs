using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotPenWidthAttribute : IDotAttribute
    {
        public float Value { get; set; }

        public DotPenWidthAttribute(float value = default)
        {
            Value = value;
        }

        public static implicit operator DotPenWidthAttribute(float? value)
        {
            return value.HasValue ? new DotPenWidthAttribute(value.Value) : null;
        }

        public static implicit operator DotPenWidthAttribute(int? value)
        {
            return value.HasValue ? new DotPenWidthAttribute(value.Value) : null;
        }
    }
}
