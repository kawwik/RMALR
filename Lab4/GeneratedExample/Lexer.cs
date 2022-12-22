using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Examples;
enum TokenType
{
    WORD,
    SPACES
}

public class ExampleTokenizer : TokenizerBase
{
    public ExampleTokenizer()
    {
        var WORD = new TokenMatcher<TokenType>(TokenType.WORD, new RegexMatcher("\\w+"));
        var SPACES = new SkipMatcher(new TokenMatcher<TokenType>(TokenType.SPACES, new RegexMatcher(" +")));
        Matchers.Add(WORD);
        Matchers.Add(SPACES);
    }
}