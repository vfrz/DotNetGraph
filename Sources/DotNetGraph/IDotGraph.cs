using DotNetGraph.Core;
using System.Collections.Generic;

namespace DotNetGraph
{
    public interface IDotGraph
    {
        string Identifier { get; set; }

        List<IDotElement> Elements { get; }
    }
}