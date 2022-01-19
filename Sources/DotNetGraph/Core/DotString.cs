namespace DotNetGraph.Core
{
    public class DotString : IDotElement
    {
        public string Value { get; set; }

        public DotString(string value = null)
        {
            Value = value;
        }
    }
}