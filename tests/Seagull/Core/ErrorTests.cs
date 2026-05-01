using System;
using Shouldly;
using Xunit;

namespace Seagull.Tests.Core;

public class ErrorTests
{
    private const string CODE = "TEST_001";
    private const string MESSAGE = "This is a base test message";

    [Fact]
    public void Error_Initializer_ShouldReturnANewInstanceWithValues()
    {
        var error = new Error(CODE, MESSAGE);

        error.Code.ShouldBe(CODE);
        error.Message.ShouldBe(MESSAGE);
    }

    [Fact]
    public void Error_Initializer_ShouldReturnANewInstanceWithEmptyValues()
    {
        var error = Error.None;

        error.Code.ShouldBe(string.Empty);
        error.Message.ShouldBe(string.Empty);
    }

    [Fact]
    public void Error_ErrorComparisson_ShouldBeOk()
    {
        var error1 = new Error(CODE, MESSAGE);
        var error2 = new Error(CODE, MESSAGE);
        var error3 = Error.None;

        Assert.True(error1 == error2);
        Assert.False(error1 != error1);
        Assert.False(error1 == error3);
        error1.ShouldBeEquivalentTo(error2);
        error1.ShouldNotBe(error3);
    }

    [Fact]
    public void Error_ConversionToString_ShouldReturnErrorCode()
    {
        var error = new Error(CODE, MESSAGE);
        var code = (string)error;

        code.ShouldBe(CODE);
    }

    [Fact]
    public void Error_Equals_ShouldReturnOk()
    {
        var error1 = new Error(CODE, MESSAGE);
        var error2 = new Error(CODE, MESSAGE);
        var error3 = Error.None;

        var comp1 = error1.Equals(error1);
        var comp2 = error1.Equals(error2);
        var comp3 = error1.Equals(error3);

        comp1.ShouldBeTrue();
        comp2.ShouldBeTrue();
        comp3.ShouldBeFalse();
    }
}
