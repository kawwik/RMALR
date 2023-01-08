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
        result.AddChildren(ReadZhopaNode(result.GetChild("kek", 1)["value"]));
        Console.WriteLine(result.GetChild("zhopa", 1)["res"]);
        return result;
    }

    public NonTerminalNode ReadKekNode()
    {
        var result = new NonTerminalNode("kek");
        result.AddChildren(ReadTerminal("XOR"));
        result["value"] = 5;
        return result;
    }

    public NonTerminalNode ReadZhopaNode(dynamic i)
    {
        var result = new NonTerminalNode("zhopa");
        result.AddChildren(ReadTerminal("OR"));
        result["res"] = i * 2;
        return result;
    }
}