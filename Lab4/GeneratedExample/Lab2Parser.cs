using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;

public class Lab2Parser : ParserBase
{
    Lab2Parser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadKekNode()
    {
        var result = new NonTerminalNode("Kek");
        switch (CurrentToken.Type)
        {
            case "OR":
                switch (CurrentToken.Type)
                {
                    case "OR":
                        result.AddChildren(ReadTerminal("OR"));
                        switch (CurrentToken.Type)
                        {
                            case "AND":
                                result.AddChildren(ReadTerminal("AND"));
                                break;
                            default:
                                throw new InvalidOperationException("Неожиданный токен");
                                break;
                        }

                        result.AddChildren(ReadTerminal("ZHOPA"));
                        break;
                    default:
                        throw new InvalidOperationException("Неожиданный токен");
                        break;
                }

                break;
            default:
                throw new InvalidOperationException("Неожиданный токен");
                break;
        }

        return result;
    }
}