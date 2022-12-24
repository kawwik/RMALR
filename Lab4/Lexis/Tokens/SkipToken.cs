namespace Lab4.Lexis.Tokens;

public class SkipToken : IToken
{
    public SkipToken(string value)
    {
        Value = value;
    }

    public string Type => "@SKIP";
    public string Value { get; }
    public int Length => Value.Length;
}