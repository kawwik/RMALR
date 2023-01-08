using Lab4.Lexis.Tokens;

namespace Lab4.Exceptions;

public class UnexpectedTokenException : Exception
{
    public UnexpectedTokenException(string message) : base(message)
    {
    }

    public UnexpectedTokenException(IToken token, string expectedType)
        : base($"Неожиданный токен {token.Type} встретился вместо {expectedType}")
    {
        Token = token;
    }

    public UnexpectedTokenException(IToken token)
        : base($"Неожиданный токен {token.Type}")
    {
        Token = token;
    }
    
    public IToken? Token { get; } 
}