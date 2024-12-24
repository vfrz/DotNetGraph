using System;

namespace DotNetGraph.Exceptions
{
    public class CompilationException : Exception
    {
        public CompilationException(string compilationError) : base(compilationError)
        {
        }
    }
}