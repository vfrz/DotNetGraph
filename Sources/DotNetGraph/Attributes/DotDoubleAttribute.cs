using System.Globalization;
using System.Threading.Tasks;
using DotNetGraph.Compilation;

namespace DotNetGraph.Attributes
{
    public class DotDoubleAttribute : IDotAttribute
    {
        public double Value { get; set; }
        
        public string Format { get; set; }

        public DotDoubleAttribute(double value, string format = "F2")
        {
            Value = value;
            Format = format;
        }

        public async Task CompileAsync(CompilationContext context)
        {
            await context.WriteAsync(Value.ToString(Format, NumberFormatInfo.InvariantInfo));
        }
        
        public static implicit operator DotDoubleAttribute(double value) => new DotDoubleAttribute(value);
    }
}