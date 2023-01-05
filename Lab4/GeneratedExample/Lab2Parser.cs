using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;

public class Lab2Parser : ParserBase
{
    public Lab2Parser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadStartNode()
    {
        var result = new NonTerminalNode("Start");
        switch (CurrentToken.Type)
        {
            case "NOT" or "VARIABLE" or "LEFT_PAR":
                result.AddChildren(ReadXorNode());
                break;
        }

        return result;
    }

    public NonTerminalNode ReadXorNode()
    {
        var result = new NonTerminalNode("Xor");
        result.AddChildren(ReadOrNode());
        result.AddChildren(ReadXorAdditionNode());
        return result;
    }

    public NonTerminalNode ReadXorAdditionNode()
    {
        var result = new NonTerminalNode("XorAddition");
        switch (CurrentToken.Type)
        {
            case "XOR":
                result.AddChildren(ReadTerminal("XOR"));
                result.AddChildren(ReadOrNode());
                result.AddChildren(ReadXorAdditionNode());
                break;
        }

        return result;
    }

    public NonTerminalNode ReadOrNode()
    {
        var result = new NonTerminalNode("Or");
        result.AddChildren(ReadAndNode());
        result.AddChildren(ReadOrAdditionNode());
        return result;
    }

    public NonTerminalNode ReadOrAdditionNode()
    {
        var result = new NonTerminalNode("OrAddition");
        switch (CurrentToken.Type)
        {
            case "OR":
                result.AddChildren(ReadTerminal("OR"));
                result.AddChildren(ReadAndNode());
                result.AddChildren(ReadOrAdditionNode());
                break;
        }

        return result;
    }

    public NonTerminalNode ReadAndNode()
    {
        var result = new NonTerminalNode("And");
        result.AddChildren(ReadTermNode());
        result.AddChildren(ReadAndAdditionNode());
        return result;
    }

    public NonTerminalNode ReadAndAdditionNode()
    {
        var result = new NonTerminalNode("AndAddition");
        switch (CurrentToken.Type)
        {
            case "AND":
                result.AddChildren(ReadTerminal("AND"));
                result.AddChildren(ReadTermNode());
                result.AddChildren(ReadAndAdditionNode());
                break;
        }

        return result;
    }

    public NonTerminalNode ReadTermNode()
    {
        var result = new NonTerminalNode("Term");
        switch (CurrentToken.Type)
        {
            case "NOT":
                result.AddChildren(ReadTerminal("NOT"));
                result.AddChildren(ReadTermNode());
                break;
            case "VARIABLE":
                result.AddChildren(ReadTerminal("VARIABLE"));
                break;
            case "LEFT_PAR":
                result.AddChildren(ReadTerminal("LEFT_PAR"));
                result.AddChildren(ReadXorNode());
                result.AddChildren(ReadTerminal("RIGHT_PAR"));
                break;
            default:
                throw new InvalidOperationException("Неожиданный токен");
                break;
        }

        return result;
    }
}