using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;

public class AttributesParser : ParserBase
{
    public AttributesParser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadStartNode()
    {
        var result = new NonTerminalNode("Start");
        result.AddChildren(ReadTerminal("NOT"));
        result.AddChildren(ReadKekNode(result["lol"]));
        return result;
    }

    public NonTerminalNode ReadKekNode(dynamic val)
    {
        var result = new NonTerminalNode("Kek");
        result.AddChildren(ReadTerminal("VARIABLE"));
        return result;
    }
}