using System;
using System.IO;
using System.Text;

namespace DotNetGraph.Compiler
{
    public class DotCompiler
    {
        private readonly DotGraph _graph;

        public DotCompiler(DotGraph graph)
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));
        }

        public string CompileToString(bool indented = false, bool formatStrings = true)
        {
            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                CompileToTextWriter(writer, indented, formatStrings);
                return builder.ToString();
            }
        }

        public void CompileToStream(Stream stream, bool indented = false, bool formatStrings = true)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            var writer = new StreamWriter(stream);
            CompileToTextWriter(writer, indented, formatStrings);
        }

        public void CompileToTextWriter(TextWriter writer, bool indented = false, bool formatStrings = true)
        {
            if (writer is null)
                throw new ArgumentNullException(nameof(writer));

            using (var worker = new DotCompilerWorker(_graph, writer, indented, formatStrings))
                worker.Compile();
        }
    }
}