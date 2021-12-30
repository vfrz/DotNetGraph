using System.IO;
using System.Text;

namespace DotNetGraph.Compiler
{
    public class DotCompiler
    {
        private readonly DotGraph _graph;

        public DotCompiler(DotGraph graph)
        {
            _graph = graph;
        }

        public string Compile(bool indented = false, bool formatStrings = true)
        {
            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                var worker = new DotCompilerWorker(_graph, writer, indented, formatStrings);
                worker.Compile();
                return builder.ToString();
            }
        }
    }
}