using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Lab4;

public static class SyntaxFactory
{
    public static LiteralExpressionSyntax StringLiteralExpression(string text) => 
        LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(text));

    public static ExpressionStatementSyntax InvocationStatement(string obj, string method, params ArgumentSyntax[] arguments)
    {
        return ExpressionStatement(
            InvocationExpression(
                MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression, 
                    IdentifierName(obj), 
                    IdentifierName(method)))
                .AddArgumentListArguments(arguments));
    }

    public static SyntaxToken PublicKeyword() => Token(SyntaxKind.PublicKeyword);
}