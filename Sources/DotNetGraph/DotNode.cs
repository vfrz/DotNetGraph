namespace DotNetGraph
{
    public class DotNode : DotElement
    {
        public string Name { get; }

        [DotAttribute("shape", DotNodeShape.Ellipse)]
        public DotNodeShape Shape { get; set; } = DotNodeShape.Ellipse;

        [DotAttribute("label", "\n")]
        public string Label { get; set; } = "\n";

        [DotAttribute("fillcolor", DotColor.Lightgrey)]
        public DotColor FillColor { get; set; } = DotColor.Lightgrey;

        [DotAttribute("fontcolor", DotColor.Black)]
        public DotColor FontColor { get; set; } = DotColor.Black;

        [DotAttribute("style", DotNodeStyle.Default)]
        public DotNodeStyle Style { get; set; } = DotNodeStyle.Default;

        [DotAttribute("height", 0.5f)]
        public float Height { get; set; } = 0.5f;

        public DotNode(string name)
        {
            Name = name;
        }
    }
}