using RMALR.Lexis.Matchers;

namespace RMALR.Lexis.Lexers;

public abstract class TokenizerBase
{
    protected readonly List<IMatcher> Matchers = new();

    public ITokenStream GetTokenStream(string str) => new TokenStream(Matchers, str);
}