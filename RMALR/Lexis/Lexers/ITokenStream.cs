using RMALR.Lexis.Tokens;

namespace RMALR.Lexis.Lexers;

public interface ITokenStream : IEnumerable<IToken>
{
    IToken NextToken();
}