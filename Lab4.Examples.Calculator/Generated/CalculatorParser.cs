using System.Numerics;
using Lab4.Lexis.Lexers;
using Lab4.Syntax.Nodes;
using Lab4.Syntax.Parser;
using Lab4.Exceptions;

public class CalculatorParser : ParserBase
{
    public CalculatorParser(ITokenStream tokenStream) : base(tokenStream)
    {
    }

    public NonTerminalNode ReadStartNode()
    {
        var result = new NonTerminalNode("start");
        result.AddChildren(ReadSumNode());
        Console.WriteLine(result.GetChild("sum", 1)["val"]);
        return result;
    }

    public NonTerminalNode ReadSumNode()
    {
        var result = new NonTerminalNode("sum");
        result.AddChildren(ReadTermNode());
        result.AddChildren(ReadSum_additionNode(result.GetChild("term", 1)["val"]));
        result["val"] = result.GetChild("sum_addition", 1)["val"];
        return result;
    }

    public NonTerminalNode ReadSum_additionNode(dynamic i)
    {
        var result = new NonTerminalNode("sum_addition");
        switch (CurrentToken.Type)
        {
            case "PLUS":
                result.AddChildren(ReadTerminal("PLUS"));
                result.AddChildren(ReadTermNode());
                result.AddChildren(ReadAddNode(i, result.GetChild("term", 1)["val"]));
                result.AddChildren(ReadSum_additionNode(result.GetChild("add", 1)["res"]));
                result["val"] = result.GetChild("sum_addition", 1)["val"];
                break;
            case "MINUS":
                result.AddChildren(ReadTerminal("MINUS"));
                result.AddChildren(ReadTermNode());
                result.AddChildren(ReadSubNode(i, result.GetChild("term", 1)["val"]));
                result.AddChildren(ReadSum_additionNode(result.GetChild("sub", 1)["res"]));
                result["val"] = result.GetChild("sum_addition", 1)["val"];
                break;
            case "RIGHT_PAR" or "@FINISH":
                result["val"] = i;
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }

    public NonTerminalNode ReadAddNode(dynamic x, dynamic y)
    {
        var result = new NonTerminalNode("add");
        result["res"] = x + y;
        return result;
    }

    public NonTerminalNode ReadSubNode(dynamic x, dynamic y)
    {
        var result = new NonTerminalNode("sub");
        result["res"] = x - y;
        return result;
    }

    public NonTerminalNode ReadTermNode()
    {
        var result = new NonTerminalNode("term");
        result.AddChildren(ReadFactNode());
        result.AddChildren(ReadMult_additionNode(result.GetChild("fact", 1)["val"]));
        result["val"] = result.GetChild("mult_addition", 1)["val"];
        return result;
    }

    public NonTerminalNode ReadMult_additionNode(dynamic i)
    {
        var result = new NonTerminalNode("mult_addition");
        switch (CurrentToken.Type)
        {
            case "MULTIPLY":
                result.AddChildren(ReadTerminal("MULTIPLY"));
                result.AddChildren(ReadFactNode());
                result.AddChildren(ReadMulNode(i, result.GetChild("fact", 1)["val"]));
                result.AddChildren(ReadMult_additionNode(result.GetChild("mul", 1)["res"]));
                result["val"] = result.GetChild("mult_addition", 1)["val"];
                break;
            case "DIVIDE":
                result.AddChildren(ReadTerminal("DIVIDE"));
                result.AddChildren(ReadFactNode());
                result.AddChildren(ReadDivNode(i, result.GetChild("fact", 1)["val"]));
                result.AddChildren(ReadMult_additionNode(result.GetChild("div", 1)["res"]));
                result["val"] = result.GetChild("mult_addition", 1)["val"];
                break;
            case "PLUS" or "MINUS" or "RIGHT_PAR" or "@FINISH":
                result["val"] = i;
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }

    public NonTerminalNode ReadMulNode(dynamic x, dynamic y)
    {
        var result = new NonTerminalNode("mul");
        result["res"] = x * y;
        return result;
    }

    public NonTerminalNode ReadDivNode(dynamic x, dynamic y)
    {
        var result = new NonTerminalNode("div");
        result["res"] = x / y;
        return result;
    }

    public NonTerminalNode ReadFactNode()
    {
        var result = new NonTerminalNode("fact");
        result.AddChildren(ReadChoose_opNode());
        result.AddChildren(ReadChoose_additionNode(result.GetChild("choose_op", 1)["val"]));
        result["val"] = result.GetChild("choose_addition", 1)["val"];
        return result;
    }

    public NonTerminalNode ReadChoose_additionNode(dynamic i)
    {
        var result = new NonTerminalNode("choose_addition");
        switch (CurrentToken.Type)
        {
            case "CHOOSE":
                result.AddChildren(ReadTerminal("CHOOSE"));
                result.AddChildren(ReadChoose_opNode());
                result.AddChildren(ReadChooseNode(i, result.GetChild("choose_op", 1)["val"]));
                result.AddChildren(ReadChoose_additionNode(result.GetChild("choose", 1)["res"]));
                result["val"] = result.GetChild("choose_addition", 1)["val"];
                break;
            case "MULTIPLY" or "DIVIDE" or "PLUS" or "MINUS" or "RIGHT_PAR" or "@FINISH":
                result["val"] = i;
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }

    public NonTerminalNode ReadChooseNode(dynamic n, dynamic k)
    {
        var result = new NonTerminalNode("choose");
        long nFact = 1;
        for (int i = 2; i <= n;
        i++ ) nFact  =  checked ( nFact * i ) ; 
        long kFact = 1;
        for (int i = 2; i <= k;
        i++ ) kFact  =  checked ( kFact * i ) ;
        ;
        long dFact = 1;
        for (int i = 2; i <= n - k;
        i++ ) dFact  =  checked ( dFact * i ) ;
        ;
        result["res"] = nFact / (kFact * dFact);
        return result;
    }

    public NonTerminalNode ReadChoose_opNode()
    {
        var result = new NonTerminalNode("choose_op");
        switch (CurrentToken.Type)
        {
            case "NUMBER":
                result.AddChildren(ReadTerminal("NUMBER"));
                result["val"] = int.Parse(result.GetChild("NUMBER", 1)["text"]);
                break;
            case "LEFT_PAR":
                result.AddChildren(ReadTerminal("LEFT_PAR"));
                result.AddChildren(ReadSumNode());
                result.AddChildren(ReadTerminal("RIGHT_PAR"));
                result["val"] = result.GetChild("sum", 1)["val"];
                break;
            default:
                throw new UnexpectedTokenException(CurrentToken);
                break;
        }

        return result;
    }
}