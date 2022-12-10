using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Examples;

public enum TokenType
{
    ZhopaToken,
}

public class ExampleTokenizer : TokenizerBase
{
    public ExampleTokenizer()
    {
        var ZhopaToken = new TokenMatcher<TokenType>(TokenType.ZhopaToken, new RegexMatcher(@"\w+"));
        Matchers.Add(ZhopaToken);
    }
}