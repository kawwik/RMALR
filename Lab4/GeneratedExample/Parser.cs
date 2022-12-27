using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;

public class ExampleParser : ParserBase
{
    ExampleParser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadsumNode()
    {
        var result = new NonTerminalNode("sum");
        switch (CurrentToken.Type)
        {
            case "DIGIT":
                result.AddChildren(ReadmultNode(), ReadTerminal("PLUS"), ReadmultNode());
                break;
            default:
                throw new InvalidOperationException("Неожиданный токен");
                break;
        }

        return result;
    }

    public NonTerminalNode ReadmultNode()
    {
        var result = new NonTerminalNode("mult");
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