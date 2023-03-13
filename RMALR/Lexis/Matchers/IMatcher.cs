using RMALR.Lexis.Tokens;

namespace RMALR.Lexis.Matchers;

public interface IMatcher
{
    public IToken MatchToken(string str);
}