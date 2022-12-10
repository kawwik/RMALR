namespace Lab4.Lexis.Matchers;

public class TokenMatcher<TTokenType> : IMatcher where TTokenType : Enum
{
    private readonly List<IMatcher> _matchers;

    public TokenMatcher(TTokenType tokenType, params IMatcher[] matchers)
    {
        _matchers = matchers.ToList();
        TokenType = tokenType;
    }
    
    public TTokenType TokenType { get; }

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