using Lab4.Lexis.Tokens;

namespace Lab4.Lexis.Matchers;

public interface IMatcher
{
    public IToken MatchToken(string str);
}