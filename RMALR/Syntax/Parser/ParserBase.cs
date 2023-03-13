using RMALR.Exceptions;
using RMALR.Lexis.Lexers;
using RMALR.Lexis.Tokens;
using RMALR.Syntax.Nodes;
using IToken = RMALR.Lexis.Tokens.IToken;

namespace RMALR.Syntax.Parser;

public abstract class ParserBase
{
    private readonly ITokenStream _tokenStream;
    protected IToken CurrentToken = default!;
    
    protected void NextToken() => CurrentToken = _tokenStream.NextToken();
    
    protected ParserBase(ITokenStream tokenStream)
    {
        _tokenStream = tokenStream;
        NextToken();
    }

    protected TerminalNode ReadTerminal(string type)
    {
        if (CurrentToken.Type == FinishToken.TokenType)
            throw new UnexpectedTokenException("Неожиданный конец файла");
        
        if (CurrentToken.Type != type)
            throw new UnexpectedTokenException(CurrentToken);

        var terminalNode = new TerminalNode(CurrentToken);
        NextToken();
        return terminalNode;
    }
}