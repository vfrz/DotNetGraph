using System;

namespace DotNetGraph.Exceptions
{
    public class AttributeTypeNotMatchException : Exception
    {
        public AttributeTypeNotMatchException(string attributeName, Type expectedType, Type currentType) : base($"Attribute with name '{attributeName}' doesn't match the expected type (expected: {expectedType}, current: {currentType})")
        {
        }
    }
}