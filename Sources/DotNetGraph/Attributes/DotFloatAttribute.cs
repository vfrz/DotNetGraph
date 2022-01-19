using System.Globalization;

namespace DotNetGraph.Attributes
{
    public class DotFloatAttribute : IDotAttribute
    {
        public float Value { get; set; }
        
        public string Format { get; set; }

        public DotFloatAttribute(float value, string format = "F2")
        {
            Value = value;
            Format = format;
        }

        public override string ToString()
        {
            return Value.ToString(Format, CultureInfo.InvariantCulture);
        }
    }
}