using DotNetGraph.Attributes;
using DotNetGraph.Core;

namespace DotNetGraph.Extensions
{
    public static class DotElementExtensions
    {
        public static T WithAttribute<T>(this T element, string name, IDotAttribute attribute) where T : DotElement
        {
            element.SetAttribute(name, attribute);
            return element;
        }
        
        public static T WithAttribute<T>(this T element, string name, string value) where T : DotElement
        {
            element.SetAttribute(name, new DotAttribute(value));
            return element;
        }
        
        public static T WithLabel<T>(this T element, string label, bool isHtml = false) where T : DotElement
        {
            element.Label = new DotLabelAttribute(label, isHtml);
            return element;
        }
        
        public static T WithFontColor<T>(this T element, string color) where T : DotElement
        {
            element.FontColor = new DotColorAttribute(color);
            return element;
        }
        
        public static T WithFontColor<T>(this T element, DotColor color) where T : DotElement
        {
            element.FontColor = new DotColorAttribute(color);
            return element;
        }
    }
}