using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Lexis.Examples;
public class CalculatorLexer : TokenizerBase
{
    public CalculatorLexer()
    {
        var PLUS = new TokenMatcher("PLUS", new RegexMatcher("\\+"));
        var MINUS = new TokenMatcher("MINUS", new RegexMatcher("-"));
        var DIVIDE = new TokenMatcher("DIVIDE", new RegexMatcher("/"));
        var MULTIPLY = new TokenMatcher("MULTIPLY", new RegexMatcher("\\*"));
        var LEFT_PAR = new TokenMatcher("LEFT_PAR", new RegexMatcher("\\("));
        var RIGHT_PAR = new TokenMatcher("RIGHT_PAR", new RegexMatcher("\\)"));
        var NUMBER = new TokenMatcher("NUMBER", new RegexMatcher("[0-9]+"));
        var SPACES = new SkipMatcher(new TokenMatcher("SPACES", new RegexMatcher(" +")));
        Matchers.Add(PLUS);
        Matchers.Add(MINUS);
        Matchers.Add(DIVIDE);
        Matchers.Add(MULTIPLY);
        Matchers.Add(LEFT_PAR);
        Matchers.Add(RIGHT_PAR);
        Matchers.Add(NUMBER);
        Matchers.Add(SPACES);
    }
}