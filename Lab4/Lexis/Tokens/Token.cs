namespace Lab4.Lexis.Tokens;

public class Token<TTokenType> : IToken where TTokenType : Enum
{
    public Token(string value, TTokenType type)
    {
        Value = value;
        Type = type;
    }

    public string Value { get; }
    public TTokenType Type { get; }
    public int Length => Value.Length;
}