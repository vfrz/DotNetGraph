using System.Text;

namespace DotNetGraph.Extensions
{
    internal static class StringBuilderExtensions
    {
        internal static StringBuilder AddIndentation(this StringBuilder builder, bool indented, int indentationLevel)
        {
            if (!indented)
                return builder;
            
            for (var i = 0; i < indentationLevel; i++)
            {
                builder.Append("\t");
            }
            
            return builder;
        }

        internal static StringBuilder AddIndentationNewLine(this StringBuilder builder, bool indented)
        {
            return indented ? builder.Append("\n") : builder;
        }
    }
}