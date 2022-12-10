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
        if (!tokenMatchers.Any()) 
            throw new ArgumentException(nameof(tokenMatchers));
        
        _tokenMatchers = tokenMatchers;
        _str = str;
    }

    public IToken NextToken()
    {
        if (_currentPosition == _str.Length)
            return new FinishToken();

        var token = _tokenMatchers
            .Select(x => x.MatchToken(_str[_currentPosition..]))
            .MaxBy(x => x.Length)!;

        if (token is ErrorToken)
            throw new Exception("Неожиданный символ");

        _currentPosition += token.Length;

        return token;
    }
}