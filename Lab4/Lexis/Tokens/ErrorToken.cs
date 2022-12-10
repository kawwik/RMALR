namespace Lab4.Lexis.Tokens;

public class ErrorToken : IToken
{
    public ErrorToken(int length)
    {
        Length = length;
    }

    public int Length { get; }
}