using Lab4.Lexis.Tokens;

namespace Lab4.Syntax.Rules;

public class EmptyRule : TokenRule
{
    public EmptyRule() : base(EmptyToken.TokenType)
    {
    }
}