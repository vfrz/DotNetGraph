namespace DotNetGraph.Attributes
{
    public class DotStringAttribute : IDotAttribute, ISurroundWithQuotes, IFormatStringValue
    {
        public string Value { get; set; }

        public DotStringAttribute(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}