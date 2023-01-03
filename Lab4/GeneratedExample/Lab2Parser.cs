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
            case "VARIABLE":
                result.AddChildren(ReadTerminal("VARIABLE"));
                switch (CurrentToken.Type)
                {
                    case "AND":
                        switch (CurrentToken.Type)
                        {
                            case "AND":
                                result.AddChildren(ReadTerminal("AND"), ReadTerminal("NOT"));
                                break;
                            default:
                                throw new InvalidOperationException("Неожиданный токен");
                                break;
                        }

                        break;
                }

                result.AddChildren(ReadTerminal("VARIABLE"));
                break;
            default:
                throw new InvalidOperationException("Неожиданный токен");
                break;
        }

        return result;
    }
}