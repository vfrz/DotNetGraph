using System;

namespace DotNetGraph.Edge
{
    [Flags]
    public enum DotEdgeStyle
    {
        Solid = 1,
        Dashed = 2,
        Dotted = 4,
        Bold = 8
    }
}