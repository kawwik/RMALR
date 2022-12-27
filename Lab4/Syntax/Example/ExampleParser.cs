using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;

public class ExampleParser : ParserBase
{
    ExampleParser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadAndNode()
    {
        var result = new NonTerminalNode("And");
        switch (CurrentToken.Type)
        {
            case "Some1" or "Some2" or "Some3":
                var XorNode = ReadTerminal("XorNode");
                result.AddChild(XorNode);
                var Zhopa = ReadZhopaNode();
                result.AddChild(Zhopa);
                break;
            default:
                throw new InvalidOperationException("Неожиданный токен");
                break;
        }

        return result;
    }
}