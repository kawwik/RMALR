namespace Lab4.Lexis.Tokens;

public interface IToken
{
    public string Value { get; }
    
    public int Length { get; }
}