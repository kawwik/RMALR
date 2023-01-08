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

    public override dynamic this[string attribute]
    {
        get
        {
            if (attribute == "TEXT")
                return Token.Value;

            throw new InvalidOperationException("Терминальный узел не содержит таких атрибутов");
        }
        set => throw new NotSupportedException("Нельзя изменить атрибуты терминального узла");
    }
}