using System.Collections;
using RMALR.Lexis.Matchers;
using RMALR.Lexis.Tokens;

namespace RMALR.Lexis.Lexers;

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
        IToken token;
        do
        {
            if (_currentPosition == _str.Length)
                return new FinishToken();

            token = _tokenMatchers
                .Select(x => x.MatchToken(_str[_currentPosition..]))
                .Where(x => x is not ErrorToken)
                .MaxBy(x => x.Length)!;

            if (token is null)
                throw new Exception("Неожиданный символ");

            _currentPosition += token.Length;
        } while (token is SkipToken);

        return token;
    }

    public IEnumerator<IToken> GetEnumerator()
    {
        IToken token;
        do
        {
            token = NextToken();
            yield return token;
        } while (token is not FinishToken);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}