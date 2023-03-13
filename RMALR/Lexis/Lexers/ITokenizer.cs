namespace RMALR.Lexis.Lexers;

public interface ITokenizer
{
    ITokenStream GetTokenStream(string str);
}