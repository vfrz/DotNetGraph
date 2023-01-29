using System;

namespace DotNetGraph.Core
{
    [Flags]
    public enum DotSubgraphStyle
    {
        Solid = 1,
        Dashed = 2,
        Dotted = 4,
        Bold = 8,
        Rounded = 16,
        Filled = 32,
        Striped = 64,
        Invis = 128
    }
}