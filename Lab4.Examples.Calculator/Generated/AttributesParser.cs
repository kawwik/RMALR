using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;
using Lab4.Exceptions;

public class AttributesParser : ParserBase
{
    public AttributesParser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadStartNode()
    {
        var result = new NonTerminalNode("start");
        switch (CurrentToken.Type)
        {
            case "NUMBER":
                result.AddChildren(ReadTerminal("NUMBER"));
                Console.WriteLine(int.Parse(result.GetChild("NUMBER", 1)["text"]) * 2);
                break;
            case "@FINISH":
                Console.WriteLine("Here is nothing");
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }
}