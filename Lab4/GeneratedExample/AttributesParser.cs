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
        var result = new NonTerminalNode("start");
        result.AddChildren(ReadKekNode());
        Console.WriteLine(result.GetChild("kek", 1)["value"] + 1);
        return result;
    }

    public NonTerminalNode ReadKekNode()
    {
        var result = new NonTerminalNode("kek");
        result.AddChildren(ReadTerminal("XOR"));
        result["value"] = 5;
        return result;
    }
}