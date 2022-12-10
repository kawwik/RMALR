using Lab4.Lexis.Matchers;
using Lab4.Lexis.Tokens;

namespace Lab4.Lexis.Lexers;

public class TokenStream<TTokenType> : ITokenStream where TTokenType : Enum
{
    private readonly List<TokenMatcher<TTokenType>> _tokenMatchers;

    private readonly string _str;
    private int _currentPosition;

    public TokenStream(List<TokenMatcher<TTokenType>> tokenMatchers, string str)
    {
        _tokenMatchers = tokenMatchers;
        _str = str;
    }

    public IToken NextToken()
    {
        if (_currentPosition == _str.Length)
            return new FinishToken();
        
        var maxMatcher = _tokenMatchers.MaxBy(x => x.GetMatchingOffset(_str[_currentPosition..]))!;
        var offset = maxMatcher.GetMatchingOffset(_str[_currentPosition..]);

        if (offset == 0)
            throw new Exception("Неожиданный символ");

        var tokenValue = _str.Substring(_currentPosition, offset);
        _currentPosition += offset;

        return new Token<TTokenType>(tokenValue, maxMatcher.TokenType);
    }
}