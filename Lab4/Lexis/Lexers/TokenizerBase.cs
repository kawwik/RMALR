using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Lexers;

public abstract class TokenizerBase
{
    protected readonly List<IMatcher> Matchers = new();

    public ITokenStream GetTokenStream(string str) => new TokenStream(Matchers, str);
}