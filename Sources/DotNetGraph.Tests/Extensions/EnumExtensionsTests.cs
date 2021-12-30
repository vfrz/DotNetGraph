using DotNetGraph.Extensions;
using NFluent;
using System;
using Xunit;

namespace DotNetGraph.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        public enum EnumWithoutFlags
        {
            One, Two, Three
        }

        [Flags]
        public enum EnumWithFlags
        {
            One = 1,
            Two = 2,
            Three = 4
        }

        [Fact]
        public void FlagsToString_WhenEnumWithoutFlagsProvided_ThenThereIsAnException()
        {
            var e = EnumWithoutFlags.One | EnumWithoutFlags.Three;

            Check.ThatCode(() => e.FlagsToString())
                .Throws<InvalidOperationException>();
        }

        [Theory]
        [InlineData(EnumWithFlags.One, "one")]
        [InlineData(default(EnumWithFlags), "")]
        [InlineData(EnumWithFlags.One | EnumWithFlags.Three, "one,three")]
        public void FlagsToString_WhenEnumWithFlagsProvided_ThenCorrectStringIsReturned(EnumWithFlags e, string expected)
        {
            var result = e.FlagsToString();
            Check.That(result).HasSameValueAs(expected);
        }
    }
}
