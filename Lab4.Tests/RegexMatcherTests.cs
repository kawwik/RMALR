using FluentAssertions;
using Lab4.Lexis;

namespace Lab4.Tests;

public class RegexMatcherTests
{
    [Theory]
    [InlineData(@"\w+", "hello", 5)]
    [InlineData(@"\w", "hello", 1)]
    [InlineData("hello", "hello", 5)]
    [InlineData("hello", "hello world", 5)]
    public void GetMatchingOffset_StringStartsWithRegex_ReturnCorrectNumber(string pattern, string str, int expectedOffset)
    {
        // Arrange.
        var sut = new RegexMatcher(pattern);
        
        // Act.
        var offset = sut.GetMatchingOffset(str);
        
        // Assert.
        offset.Should().Be(expectedOffset);
    }
    
    [Theory]
    [InlineData(@"\d", "hello world")]
    [InlineData("World", "helloWorld")]
    [InlineData(@"\w+", "")]
    public void GetMatchingOffset_StringDoesntStartWithRegex_ReturnZero(string pattern, string str)
    {
        // Arrange.
        var sut = new RegexMatcher(pattern);
        
        // Act.
        var offset = sut.GetMatchingOffset(str);
        
        // Assert.
        offset.Should().Be(0);
    }
}