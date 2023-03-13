using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RMALR.Syntax.Nodes;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static RMALR.Syntax.SyntaxFactory;

namespace RMALR.Syntax;

public static class AttributeService
{
    public static string ReplaceAttributeCalls(string code)
    {
        return Regex.Replace(
            code,
            @"\$[A-Za-z_]+[0-9]*(.[a-z][A-Za-z_]*)?",
            match => ParseAttributeCall(match.Value).ToString());
    }
    
    public static ExpressionSyntax ParseAttributeCall(string attributeCall)
    {
        if (!attributeCall.StartsWith("$"))
            return IdentifierName(attributeCall);

        var attributeChain = attributeCall.TrimStart('$').Split('.');

        if (attributeChain.Length == 1)
        {
            return ElementAccessExpression(IdentifierName("result"))
                .AddArgumentListArguments(Argument(StringLiteralExpression(attributeChain.Single())));
        }

        if (attributeChain.Length != 2)
            throw new NotSupportedException("Не поддерживается вложенное обращение к атрибутам");

        // TODO: возможно надо делать capitalize

        var regex = new Regex(@"(\w+)(\d+)");
        var match = regex.Match(attributeChain[0]);
        
        var number = 1;
        var child = attributeChain[0];
        if (match.Success)
        {
            number = int.Parse(match.Groups[2].Captures[0].Value);
            child = match.Groups[1].Captures[0].Value;
        }

        var childExpression = InvocationExpression(MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("result"),
                IdentifierName(nameof(NonTerminalNode.GetChild))))
            .AddArgumentListArguments(
                Argument(StringLiteralExpression(child)),
                Argument(LiteralExpression(
                    SyntaxKind.NumericLiteralExpression,
                    Literal(number))));

        return ElementAccessExpression(childExpression)
            .AddArgumentListArguments(Argument(StringLiteralExpression(attributeChain[1])));
    }
}