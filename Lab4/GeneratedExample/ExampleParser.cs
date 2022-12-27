using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;

public class ExampleParser : ParserBase
{
    ExampleParser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadSumNode()
    {
        var result = new NonTerminalNode("Sum");
        switch (CurrentToken.Type)
        {
            case "DIGIT":
                result.AddChildren(ReadMultNode(), ReadTerminal("PLUS"), ReadMultNode());
                break;
            default:
                throw new InvalidOperationException("Неожиданный токен");
                break;
        }

        return result;
    }

    public NonTerminalNode ReadMultNode()
    {
        var result = new NonTerminalNode("Mult");
        switch (CurrentToken.Type)
        {
            case "DIGIT":
                result.AddChildren(ReadTerminal("DIGIT"), ReadTerminal("MULT"), ReadTerminal("DIGIT"));
                break;
            default:
                throw new InvalidOperationException("Неожиданный токен");
                break;
        }

        return result;
    }
}