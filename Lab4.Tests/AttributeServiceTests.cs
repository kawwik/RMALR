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
        var sut = new AttributesService();

        // Act.
        var result = sut.ParseAttributeCall(call);

        // Assert.
        result.ToString().Should().Be(expected);
    }
}