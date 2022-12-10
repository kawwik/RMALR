namespace Lab4.Lexis.Tokens;

public class SkipToken : IToken
{
    public SkipToken(int length)
    {
        Length = length;
    }

    public int Length { get; }
}