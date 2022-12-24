namespace Lab4.Syntax.Rules;

public class TokenRule : RuleBase
{
    public TokenRule(string tokenType)
    {
        TokenType = tokenType;
    }

    public string TokenType { get; }
}