namespace Lab4.Lexis.Tokens;

public interface INonFinishToken<TTokenType> : IToken where TTokenType : Enum
{
    public string Value { get; }
    public TTokenType Type { get; }
}