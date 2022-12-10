namespace Lab4.Lexis.Tokens;

public class Token<TTokenType> : INonFinishToken<TTokenType> where TTokenType : Enum
{
    public Token(string value, TTokenType type)
    {
        Value = value;
        Type = type;
    }

    public string Value { get; }
    public TTokenType Type { get; }
}