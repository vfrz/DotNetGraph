namespace DotNetGraph.Attributes
{
    public class DotCustomAttribute : IDotAttribute
    {
        public string Value { get; }

        public DotCustomAttribute(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}