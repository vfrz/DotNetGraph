using System;

namespace DotNetGraph.Core
{
    [Flags]
    public enum DotEdgeStyle
    {
        Solid = 1,
        Dashed = 2,
        Dotted = 4,
        Bold = 8,
        Tapered = 16,
        Invis = 32
    }
}