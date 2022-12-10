using Lab4.Lexis.Tokens;

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

    public IToken MatchToken(string str)
    {
        int currentIndex = 0;

        foreach (var matcher in _matchers)
        {
            var token = matcher.MatchToken(str[currentIndex..]);

            if (token is ErrorToken) return token;
            
            currentIndex += token.Length;
        }

        return new Token<TTokenType>(str[..currentIndex], TokenType);
    }
}