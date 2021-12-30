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

        public string Compile(bool indented = false, bool formatStrings = true)
        {
            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                Compile(writer, indented, formatStrings);
                return builder.ToString();
            }
        }

        public void Compile(Stream stream, bool indented = false, bool formatStrings = true)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var writer = new StreamWriter(stream);
            Compile(writer, indented, formatStrings);
        }

        public void Compile(TextWriter writer, bool indented = false, bool formatStrings = true)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            using (var worker = new DotCompilerWorker(_graph, writer, indented, formatStrings))
            {
                worker.Compile();
            }
        }
    }
}