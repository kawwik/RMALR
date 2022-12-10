namespace Lab4.Lexis.Tokens;

public class RegexToken : IToken
{
    public RegexToken(int length)
    {
        Length = length;
    }

    public int Length { get; }
}