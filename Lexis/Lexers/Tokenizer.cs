namespace Lab4.Lexis.Lexers;

public class Tokenizer : ITokenizer
{
    private readonly List<TokenMatcher> _matchers;

    public Tokenizer(List<TokenMatcher> matchers)
    {
        _matchers = matchers;
    }

    public ITokenStream GetTokenStream(string str) => new TokenStream(_matchers, str);
}