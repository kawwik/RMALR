namespace Lab4.Lexis.Tokens;

public class RegexToken : IToken
{
    public RegexToken(string value)
    {
        Value = value;
    }

    public string Type => "@REGEX";
    public string Value { get; }
    public int Length => Value.Length;
}