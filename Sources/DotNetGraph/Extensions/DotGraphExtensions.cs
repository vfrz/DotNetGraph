using DotNetGraph.Compiler;
using System.IO;

namespace DotNetGraph.Extensions
{
    public static class DotGraphExtensions
    {
        public static string Compile(this DotGraph graph, bool indented = false, bool formatStrings = true)
        {
            return new DotCompiler(graph).Compile(indented, formatStrings);
        }

        public static void Compile(this DotGraph graph, Stream stream, bool indented = false, bool formatStrings = true)
        {
            new DotCompiler(graph).Compile(stream, indented, formatStrings);
        }

        public static void Compile(this DotGraph graph, TextWriter writer, bool indented = false, bool formatStrings = true)
        {
            new DotCompiler(graph).Compile(writer, indented, formatStrings);
        }
    }
}