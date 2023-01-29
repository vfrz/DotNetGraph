namespace DotNetGraph.Core
{
    public struct DotPoint
    {
        public int X;

        public int Y;

        public int? Z;

        public bool Fixed;

        public DotPoint(int x, int y, bool @fixed = false)
        {
            X = x;
            Y = y;
            Z = null;
            Fixed = @fixed;
        }

        public DotPoint(int x, int y, int z, bool @fixed = false)
        {
            X = x;
            Y = y;
            Z = z;
            Fixed = @fixed;
        }

        public override string ToString()
        {
            var value = $"{X},{Y}";
            if (Z != null)
                value += $",{Z}";
            if (Fixed)
                value += "!";
            return value;
        }
    }
}