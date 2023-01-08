using FluentAssertions;
using Lab4.Syntax;

namespace Lab4.Tests;

public class AttributeServiceTests
{
    [Theory]
    [InlineData("val", "val")]
    [InlineData("$val", @"result[""val""]")]
    [InlineData("$expr.val", @"result.GetChild(""expr"",1)[""val""]")]
    [InlineData("$expr1.val", @"result.GetChild(""expr"",1)[""val""]")]
    [InlineData("$expr2.val", @"result.GetChild(""expr"",2)[""val""]")]
    public void ParseAttributeCall_CorrectlyParsed(string call, string expected)
    {
        // Arrange.

        // Act.
        var result = AttributeService.ParseAttributeCall(call);

        // Assert.
        result.ToString().Should().Be(expected);
    }

    [Theory]
    [InlineData("$val", @"result[""val""]")]
    [InlineData(@"Console.WriteLine($val);", @"Console.WriteLine(result[""val""]);")]
    [InlineData(@"val = $exprP.val;", @"val = result.GetChild(""exprP"",1)[""val""];")]
    [InlineData(@"val = $exprP1.val;", @"val = result.GetChild(""exprP"",1)[""val""];")]
    [InlineData(@"val = $exprP2.val;", @"val = result.GetChild(""exprP"",2)[""val""];")]
    public void ReplaceAttributeCalls_CorrectlyReplaced(string code, string expected)
    {
        // Arrange.

        // Act.
        var result = AttributeService.ReplaceAttributeCalls(code);

        // Assert.
        result.Should().Be(expected);
    }
}