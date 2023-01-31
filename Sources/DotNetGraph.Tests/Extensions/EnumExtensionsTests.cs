using System;
using DotNetGraph.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGraph.Tests.Extensions;

[TestClass]
public class EnumExtensionsTests
{
    [Flags]
    private enum TestFlaggedEnum
    {
        Hello = 1,
        World = 2,
        Lorem = 4,
        Ipsum = 8
    }

    private enum TestNonFlaggedEnum
    {
        Hello,
        World
    }
    
    [TestMethod]
    public void FlagsToStringNoFlag()
    {
        var value = (TestFlaggedEnum) 0;

        var result = value.FlagsToString();

        result.Should().BeEmpty();
    }
    
    [TestMethod]
    public void FlagsToStringOneFlag()
    {
        var value = TestFlaggedEnum.Lorem;

        var result = value.FlagsToString();

        result.Should().Be("lorem");
    }
    
    [TestMethod]
    public void FlagsToStringMultipleFlags()
    {
        var value = TestFlaggedEnum.Hello | TestFlaggedEnum.World | TestFlaggedEnum.Ipsum;

        var result = value.FlagsToString();

        result.Should().Be("hello,world,ipsum");
    }
    
    [TestMethod]
    public void FlagsToStringNonFlaggedEnum()
    {
        var value = TestNonFlaggedEnum.Hello;

        value.Invoking(v => v.FlagsToString())
            .Should()
            .Throw<Exception>();
    }
}