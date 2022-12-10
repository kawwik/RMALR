using System.Text.RegularExpressions;

namespace Lab4.Lexis.Matchers;

public class RegexMatcher : IMatcher
{
    private readonly Regex _regex;
    
    public RegexMatcher(string pattern)
    {
        _regex = new Regex(pattern, RegexOptions.Compiled);
    }
    
    public int GetMatchingOffset(string str)
    {
        var match = _regex.Match(str);

        return match.Index == 0 ? match.Length : 0;
    }
}