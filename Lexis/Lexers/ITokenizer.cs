namespace Lab4.Lexis.Lexers;

public interface ITokenizer
{
    ITokenStream GetTokenStream(string str);
}