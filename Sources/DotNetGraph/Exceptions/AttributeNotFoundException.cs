using System;

namespace DotNetGraph.Exceptions
{
    public class AttributeNotFoundException : Exception
    {
        public AttributeNotFoundException(string attributeName) : base($"There is no attribute named '{attributeName}'")
        {
        }
    }
}