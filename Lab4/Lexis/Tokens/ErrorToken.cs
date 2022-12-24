namespace Lab4.Lexis.Tokens;

public class ErrorToken : IToken
{
    public ErrorToken(string value)
    {
        Value = value;
    }

    public string Type => "@ERROR";
    public string Value { get; }
    public int Length => Value.Length;
}