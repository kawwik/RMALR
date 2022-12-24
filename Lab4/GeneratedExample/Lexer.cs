using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Examples;
public class ExampleTokenizer : TokenizerBase
{
    public ExampleTokenizer()
    {
        var WORD = new TokenMatcher("WORD", new RegexMatcher("\\w+"));
        var SPACES = new SkipMatcher(new TokenMatcher("SPACES", new RegexMatcher(" +")));
        Matchers.Add(WORD);
        Matchers.Add(SPACES);
    }
}