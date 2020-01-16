using System.Collections.Generic;

namespace DotNetGraph.Core
{
    public interface IElementWithChildren
    {
        List<IDotElement> Elements { get; }
    }
}