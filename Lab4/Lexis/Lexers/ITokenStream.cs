using Lab4.Lexis.Tokens;

namespace Lab4.Lexis.Lexers;

public interface ITokenStream : IEnumerable<IToken>
{
    IToken NextToken();
}