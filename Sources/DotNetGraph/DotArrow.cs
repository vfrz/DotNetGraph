namespace DotNetGraph
{
    public class DotArrow : DotElement
    {
        public string StartNodeName { get; }

        public string TargetNodeName { get; }

        [DotAttribute("arrowhead", DotArrowShape.Normal)]
        public DotArrowShape ArrowHeadShape { get; set; } = DotArrowShape.Normal;

        [DotAttribute("color", DotColor.Black)]
        public DotColor ArrowColor { get; set; } = DotColor.Black;

        [DotAttribute("fontcolor", DotColor.Black)]
        public DotColor FontColor { get; set; } = DotColor.Black;

        [DotAttribute("label", "\n")]
        public string ArrowLabel { get; set; } = "\n";

        public DotArrow(string startNodeName, string targetNodeName)
        {
            StartNodeName = startNodeName;
            TargetNodeName = targetNodeName;
        }

        public DotArrow(DotNode startNode, DotNode targetNode) : this(startNode.Name, targetNode.Name)
        {
        }
    }
}