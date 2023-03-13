using RMALR.Syntax.Rules.BaseClasses;

namespace RMALR.Syntax.Rules;

public class TokenRule : UnnamedRule
{
    public TokenRule(string tokenType)
    {
        TokenType = tokenType;
    }

    public string TokenType { get; }

    protected override HashSet<string> FirstInternal() => new(new[] {TokenType});
}