using DotNetGraph.Attributes;

namespace DotNetGraph.Node
{
    public class DotNodeStyleLayout
    {
        public DotColorAttribute Color { get; set; }

        public DotFontColorAttribute FontColor { get; set; }
        
        public DotFillColorAttribute FillColor { get; set; }
        
        public DotNodeShapeAttribute Shape { get; set; }
        
        public DotNodeStyleAttribute Style { get; set; }
        
        public DotNodeHeightAttribute Height { get; set; }
    }
}