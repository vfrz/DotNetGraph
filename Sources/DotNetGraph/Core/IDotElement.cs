using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public interface IDotElement
    {
        string Compile(CompilationOptions options);
    }
}