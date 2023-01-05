using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;

public class Lab2Parser : ParserBase
{
    public Lab2Parser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadANode()
    {
        var result = new NonTerminalNode("A");
        switch (CurrentToken.Type)
        {
            case "AND":
                break;
            case "NOT":
                break;
        }

        return result;
    }
}