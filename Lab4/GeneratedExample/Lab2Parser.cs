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
        result.AddChildren(ReadTerminal("VARIABLE"));
        switch (CurrentToken.Type)
        {
            case "AND":
                result.AddChildren(ReadTerminal("AND"));
                result.AddChildren(ReadTerminal("NOT"));
                break;
            case "NOT":
                result.AddChildren(ReadTerminal("NOT"));
                break;
        }

        result.AddChildren(ReadTerminal("VARIABLE"));
        return result;
    }
}