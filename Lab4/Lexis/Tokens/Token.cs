namespace Lab4.Lexis.Tokens;

public class Token: IToken
{
    public Token(string value, string type)
    {
        Value = value;
        Type = type;
    }

    public string Value { get; }
    public string Type { get; }
    public int Length => Value.Length;
}