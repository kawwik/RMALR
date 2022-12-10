using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Examples;

public enum TokenType
{
    WORD,
    SPACES,
}

public class ExampleTokenizer : TokenizerBase
{
    public ExampleTokenizer()
    {
        var WORD = new TokenMatcher<TokenType>(TokenType.WORD, new RegexMatcher(@"\w+"));
        Matchers.Add(WORD);
        var SPACES = new TokenMatcher<TokenType>(TokenType.SPACES, new RegexMatcher(@" +"));
        var SPACES_SKIPPER = new SkipMatcher(SPACES);
        Matchers.Add(SPACES_SKIPPER);
    }
}