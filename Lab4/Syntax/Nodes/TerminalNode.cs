using Lab4.Lexis.Tokens;

namespace Lab4.Syntax.Nodes;

public class TerminalNode : Node
{
    public TerminalNode(IToken token)
    {
        Token = token;
    }

    public IToken Token { get; }

    public override string Type => Token.Type;
}