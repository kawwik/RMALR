using Lab4.Lexis.Tokens;

namespace Lab4.Lexis.Matchers;

public class SkipMatcher : IMatcher
{
    private readonly IMatcher _matcher;

    public SkipMatcher(IMatcher matcher)
    {
        _matcher = matcher;
    }

    public IToken MatchToken(string str)
    {
        var token = _matcher.MatchToken(str);

        return token switch
        {
            ErrorToken => token,
            _ => new SkipToken(token.Value)
        };
    }
}