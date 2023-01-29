using System.IO;
using System.Threading.Tasks;

namespace DotNetGraph.Compilation
{
    public class CompilationContext
    {
        public TextWriter TextWriter { get; }

        public CompilationOptions Options { get; }

        public int IndentationLevel { get; set; }
        
        public bool DirectedGraph { get; set; }

        public CompilationContext(TextWriter textWriter, CompilationOptions options)
        {
            TextWriter = textWriter;
            Options = options;
            IndentationLevel = 0;
            DirectedGraph = false;
        }

        public async Task WriteIndentationAsync()
        {
            if (!Options.Indented)
                return;

            for (var i = 0; i < IndentationLevel; i++)
                await TextWriter.WriteAsync("\t");
        }

        public async Task WriteAsync(string value)
        {
            await TextWriter.WriteAsync(value);
        }

        public async Task WriteLineAsync(string value = null)
        {
            await TextWriter.WriteAsync(value);
            await TextWriter.WriteAsync(Options.Indented ? '\n' : ' ');
        }
    }
} 