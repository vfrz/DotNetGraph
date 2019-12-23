using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotLabelAttribute : IDotAttribute
    {
        public string Text { get; set; }
        
        public DotLabelAttribute(string text = default)
        {
            Text = text;
        }

        public static implicit operator DotLabelAttribute(string text)
        {
            return text is null ? null : new DotLabelAttribute(text);
        }
    }
}