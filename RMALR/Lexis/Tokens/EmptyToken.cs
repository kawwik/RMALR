namespace RMALR.Lexis.Tokens;

public class EmptyToken : IToken
{
    public const string TokenType = "@EMPTY";

    public string Type => TokenType;
    public string Value => string.Empty;
    public int Length => 0;
}