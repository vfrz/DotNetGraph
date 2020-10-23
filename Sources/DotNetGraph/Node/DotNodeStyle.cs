using System;

namespace DotNetGraph.Node
{
    [Flags]
    public enum DotNodeStyle
    {
        Solid = 1,
        Dashed = 2,
        Dotted = 4,
        Bold = 8,
        Rounded = 16,
        Diagonals = 32,
        Filled = 64,
        Striped = 128,
        Wedged = 256
    }
}