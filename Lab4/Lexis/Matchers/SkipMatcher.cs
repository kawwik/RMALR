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

        if (token is ErrorToken)
            return new ErrorToken(token.Length);

        return new SkipToken(token.Length);
    }
}