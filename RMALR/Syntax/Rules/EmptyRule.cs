using RMALR.Lexis.Tokens;

namespace RMALR.Syntax.Rules;

public class EmptyRule : TokenRule
{
    public EmptyRule() : base(EmptyToken.TokenType)
    {
    }
}