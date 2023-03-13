using System.Numerics;
using RMALR.Lexis.Lexers;
using RMALR.Syntax.Nodes;
using RMALR.Syntax.Parser;
using RMALR.Exceptions;

public class PythonLogicParser : ParserBase
{
    public PythonLogicParser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadStartNode()
    {
        var result = new NonTerminalNode("start");
        switch (CurrentToken.Type)
        {
            case "NOT" or "VARIABLE" or "LEFT_PAR":
                result.AddChildren(ReadXorNode());
                break;
            case "@FINISH":
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }

    public NonTerminalNode ReadXorNode()
    {
        var result = new NonTerminalNode("xor");
        result.AddChildren(ReadOrNode());
        result.AddChildren(ReadXorAdditionNode());
        return result;
    }

    public NonTerminalNode ReadXorAdditionNode()
    {
        var result = new NonTerminalNode("xorAddition");
        switch (CurrentToken.Type)
        {
            case "XOR":
                result.AddChildren(ReadTerminal("XOR"));
                result.AddChildren(ReadOrNode());
                result.AddChildren(ReadXorAdditionNode());
                break;
            case "RIGHT_PAR" or "@FINISH":
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }

    public NonTerminalNode ReadOrNode()
    {
        var result = new NonTerminalNode("or");
        result.AddChildren(ReadAndNode());
        result.AddChildren(ReadOrAdditionNode());
        return result;
    }

    public NonTerminalNode ReadOrAdditionNode()
    {
        var result = new NonTerminalNode("orAddition");
        switch (CurrentToken.Type)
        {
            case "OR":
                result.AddChildren(ReadTerminal("OR"));
                result.AddChildren(ReadAndNode());
                result.AddChildren(ReadOrAdditionNode());
                break;
            case "XOR" or "RIGHT_PAR" or "@FINISH":
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }

    public NonTerminalNode ReadAndNode()
    {
        var result = new NonTerminalNode("and");
        result.AddChildren(ReadTermNode());
        result.AddChildren(ReadAndAdditionNode());
        return result;
    }

    public NonTerminalNode ReadAndAdditionNode()
    {
        var result = new NonTerminalNode("andAddition");
        switch (CurrentToken.Type)
        {
            case "AND":
                result.AddChildren(ReadTerminal("AND"));
                result.AddChildren(ReadTermNode());
                result.AddChildren(ReadAndAdditionNode());
                break;
            case "OR" or "XOR" or "RIGHT_PAR" or "@FINISH":
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }

    public NonTerminalNode ReadTermNode()
    {
        var result = new NonTerminalNode("term");
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
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }
}