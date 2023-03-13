using System.Text.RegularExpressions;
using RMALR.Lexis.Tokens;

namespace RMALR.Lexis.Matchers;

public class RegexMatcher : IMatcher
{
    private readonly Regex _regex;
    
    public RegexMatcher(string pattern)
    {
        _regex = new Regex(pattern, RegexOptions.Compiled);
    }
    
    public IToken MatchToken(string str)
    {
        var match = _regex.Match(str);

        return match.Index switch
        {
            0 => new RegexToken(match.Value),
            _ => new ErrorToken(match.Value)
        };
    }
}