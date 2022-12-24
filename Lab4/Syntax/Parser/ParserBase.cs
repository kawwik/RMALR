using Lab4.Exceptions;
using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using IToken = Lab4.Lexis.Tokens.IToken;

namespace Lab4.Syntax.Parser;

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
        if (CurrentToken.Type != type)
            throw new UnexpectedTokenException("Неожиданный токен");

        var terminalNode = new TerminalNode(CurrentToken);
        NextToken();
        return terminalNode;
    }
}