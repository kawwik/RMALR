using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Examples;
public class ExampleTokenizer : TokenizerBase
{
    public ExampleTokenizer()
    {
        var DIGIT = new TokenMatcher("DIGIT", new RegexMatcher("\\d"));
        var PLUS = new TokenMatcher("PLUS", new RegexMatcher("\\+"));
        var SPACES = new SkipMatcher(new TokenMatcher("SPACES", new RegexMatcher(" +")));
        Matchers.Add(DIGIT);
        Matchers.Add(PLUS);
        Matchers.Add(SPACES);
    }
}