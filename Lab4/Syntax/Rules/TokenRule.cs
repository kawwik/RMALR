using Lab4.Syntax.Rules.BaseClasses;

namespace Lab4.Syntax.Rules;

public class TokenRule : UnnamedRule
{
    public TokenRule(string tokenType)
    {
        TokenType = tokenType;
    }

    public string TokenType { get; }

    protected override HashSet<string> FirstInternal() => new(new[] {TokenType});
}