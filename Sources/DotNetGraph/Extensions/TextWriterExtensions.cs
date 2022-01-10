using System;
using System.IO;

namespace DotNetGraph.Extensions
{
    internal static class TextWriterExtensions
    {
        public static TextWriter AddIndentation(this TextWriter writer, bool indented, int indentationLevel)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (!indented)
                return writer;

            for (var i = 0; i < indentationLevel; i++)
            {
                writer.Write("\t");
            }

            return writer;
        }

        public static TextWriter AddIndentationNewLine(this TextWriter writer, bool indented)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (indented)
            {
                writer.Write("\n");
            }

            return writer;
        }
    }
}