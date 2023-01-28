using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public interface IDotElement
    {
        Task CompileAsync(CompilationContext context);
    }
}