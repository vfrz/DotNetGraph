namespace DotNetGraph.Core
{
    public class DotPosition
    {
        public int X { get; set; }
        
        public int Y { get; set; }

        public DotPosition()
        {
        }

        public DotPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}