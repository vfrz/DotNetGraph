using System;

namespace DotNetGraph.SubGraph
{
    [Flags]
    public enum DotSubGraphStyle
    {
        Solid = 1,
        Dashed = 2,
        Dotted = 4,
        Bold = 8,
        Rounded = 16,
        Filled = 32,
        Striped = 64
    }
}