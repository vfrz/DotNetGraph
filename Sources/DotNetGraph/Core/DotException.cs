using System;

namespace DotNetGraph.Core
{
    public class DotException : Exception
    {
        public DotException(string message) : base(message)
        {
        }
    }
}