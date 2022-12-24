namespace Lab4.Lexis.Tokens;

public class FinishToken : IToken
{
    public string Type => "@FINISH";
    public string Value => string.Empty;
    public int Length => 0;
}