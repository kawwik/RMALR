using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Examples;

public enum TokenType
{
    WordToken,
    SPACES,
}

public class ExampleTokenizer : TokenizerBase
{
    public ExampleTokenizer()
    {
        var WordToken = new TokenMatcher<TokenType>(TokenType.WordToken, new RegexMatcher(@"\w+"));
        Matchers.Add(WordToken);
        var SPACES = new TokenMatcher<TokenType>(TokenType.SPACES, new RegexMatcher(@" +"));
        var SPACES_SKIPPER = new SkipMatcher(SPACES);
        Matchers.Add(SPACES_SKIPPER);
    }
}