using DotNetGraph.Core;
using System.Collections.Generic;

namespace DotNetGraph
{
    public interface IDotGraph
    {
        List<IDotElement> Elements { get; }
        string Identifier { get; set; }
    }
}
