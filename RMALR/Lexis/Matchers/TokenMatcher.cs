using RMALR.Lexis.Tokens;

namespace RMALR.Lexis.Matchers;

public class TokenMatcher: IMatcher
{
    private readonly List<IMatcher> _matchers;

    public TokenMatcher(string tokenType, params IMatcher[] matchers)
    {
        _matchers = matchers.ToList();
        TokenType = tokenType;
    }
    
    public string TokenType { get; }

    public IToken MatchToken(string str)
    {
        int currentIndex = 0;

        foreach (var matcher in _matchers)
        {
            var token = matcher.MatchToken(str[currentIndex..]);

            if (token is ErrorToken) return token;
            
            currentIndex += token.Length;
        }

        return new Token(str[..currentIndex], TokenType);
    }
}