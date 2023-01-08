using Lab4.Lexis.Lexers;
using Lab4.Lexis.Matchers;

namespace Lab4.Examples.Calculator.Generated;
public class AttributesLexer : TokenizerBase
{
    public AttributesLexer()
    {
        var AND = new TokenMatcher("AND", new RegexMatcher("and"));
        var OR = new TokenMatcher("OR", new RegexMatcher("or"));
        var XOR = new TokenMatcher("XOR", new RegexMatcher("xor"));
        var NOT = new TokenMatcher("NOT", new RegexMatcher("not"));
        var LEFT_PAR = new TokenMatcher("LEFT_PAR", new RegexMatcher("\\("));
        var RIGHT_PAR = new TokenMatcher("RIGHT_PAR", new RegexMatcher("\\)"));
        var VARIABLE = new TokenMatcher("VARIABLE", new RegexMatcher("[a-z]"));
        var SPACES = new SkipMatcher(new TokenMatcher("SPACES", new RegexMatcher(" +")));
        Matchers.Add(AND);
        Matchers.Add(OR);
        Matchers.Add(XOR);
        Matchers.Add(NOT);
        Matchers.Add(LEFT_PAR);
        Matchers.Add(RIGHT_PAR);
        Matchers.Add(VARIABLE);
        Matchers.Add(SPACES);
    }
}