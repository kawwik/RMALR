using Lab4.Lexis.Tokens;

namespace Lab4.Lexis.Matchers;

public class TokenMatcher : IMatcher
{
    private readonly List<IMatcher> _matchers;

    public TokenMatcher(TokenType tokenType, params IMatcher[] matchers)
    {
        _matchers = matchers.ToList();
        TokenType = tokenType;
    }
    
    public TokenType TokenType { get; }

    public int GetMatchingOffset(string str)
    {
        int currentIndex = 0;

        foreach (var matcher in _matchers)
        {
            var offset = matcher.GetMatchingOffset(str[currentIndex..]);
            if (offset == 0)
                return 0;

            currentIndex += offset;
        }

        return currentIndex > str.Length ? 0 : currentIndex;
    }
}