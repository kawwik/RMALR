namespace Lab4.Lexis.Tokens;

public class FinishToken : IToken
{
    public const string TokenType = "@FINISH";
    public string Type => TokenType;
    public string Value => string.Empty;
    public int Length => 0;
}