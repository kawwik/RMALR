namespace Lab4.Lexis.Tokens;

public interface IToken
{
    string Value { get; }

    TokenType Type { get; }
}