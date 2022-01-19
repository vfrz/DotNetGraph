namespace DotNetGraph.Core
{
    public struct DotPosition
    {
        public int X { get; set; }

        public int Y { get; set; }
        
        public bool Fixed { get; set; }

        public DotPosition(int x, int y, bool @fixed = true)
        {
            X = x;
            Y = y;
            Fixed = @fixed;
        }
    }
}