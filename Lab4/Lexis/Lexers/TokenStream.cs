using Lab4.Lexis.Matchers;
using Lab4.Lexis.Tokens;

namespace Lab4.Lexis.Lexers;

public class TokenStream : ITokenStream
{
    private readonly List<IMatcher> _tokenMatchers;

    private readonly string _str;
    private int _currentPosition;

    public TokenStream(List<IMatcher> tokenMatchers, string str)
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