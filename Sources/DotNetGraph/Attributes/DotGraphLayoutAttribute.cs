using DotNetGraph.Core;

namespace DotNetGraph.Attributes
{
    public class DotGraphLayoutAttribute : IDotAttribute
    {
        public DotGraphLayout Layout { get; set; }

        public DotGraphLayoutAttribute(DotGraphLayout layout = DotGraphLayout.Dot)
        {
            Layout = layout;
        }

        public static implicit operator DotGraphLayoutAttribute(DotGraphLayout? layout)
        {
            return layout.HasValue ? new DotGraphLayoutAttribute(layout.Value) : null;
        }
    }
}