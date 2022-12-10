using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Lexers;

public abstract class TokenizerBase<TTokenType> : ITokenizer where TTokenType : Enum
{
    protected readonly List<TokenMatcher<TTokenType>> Matchers = new();

    public ITokenStream GetTokenStream(string str) => new TokenStream<TTokenType>(Matchers, str);
}