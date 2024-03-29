using RMALR.Lexis.Lexers;
using RMALR.Lexis.Matchers;

namespace RMALR.Lexis.Examples;
public class PythonLogicLexer : TokenizerBase
{
    public PythonLogicLexer()
    {
        var PLUS = new TokenMatcher("PLUS", new RegexMatcher("\\+"));
        var MINUS = new TokenMatcher("MINUS", new RegexMatcher("-"));
        var DIVIDE = new TokenMatcher("DIVIDE", new RegexMatcher("/"));
        var MULTIPLY = new TokenMatcher("MULTIPLY", new RegexMatcher("\\*"));
        var CHOOSE = new TokenMatcher("CHOOSE", new RegexMatcher("choose"));
        var LEFT_PAR = new TokenMatcher("LEFT_PAR", new RegexMatcher("\\("));
        var RIGHT_PAR = new TokenMatcher("RIGHT_PAR", new RegexMatcher("\\)"));
        var NUMBER = new TokenMatcher("NUMBER", new RegexMatcher("[0-9]+"));
        var SPACES = new SkipMatcher(new TokenMatcher("SPACES", new RegexMatcher(" +")));
        Matchers.Add(PLUS);
        Matchers.Add(MINUS);
        Matchers.Add(DIVIDE);
        Matchers.Add(MULTIPLY);
        Matchers.Add(CHOOSE);
        Matchers.Add(LEFT_PAR);
        Matchers.Add(RIGHT_PAR);
        Matchers.Add(NUMBER);
        Matchers.Add(SPACES);
    }
}