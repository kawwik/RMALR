using Lab4.Syntax.Nodes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Lab4.SyntaxFactory;

namespace Lab4.Syntax.Parser.Builders;

public class MethodBuilder
{
    private MethodDeclarationSyntax _methodDeclaration;

    public MethodBuilder(string returnType, string methodName)
    {
        _methodDeclaration = MethodDeclaration(ParseTypeName(returnType), methodName);
    }

    private MethodBuilder(MethodDeclarationSyntax methodDeclaration) => _methodDeclaration = methodDeclaration;

    public static MethodBuilder BuildParserMethod(string nodeType, SwitchBuilder switchBuilder)
    {
        const string resultVariableName = "result";

        var method = MethodDeclaration(ParseTypeName(nameof(NonTerminalNode)), $"Read{nodeType}Node")
            .AddBodyStatements(
                LocalDeclarationStatement(
                    VariableDeclarationWithCreation(
                        resultVariableName,
                        ParseTypeName(nameof(NonTerminalNode)),
                        Argument(StringLiteralExpression(nodeType)))),
                switchBuilder.GetSwitchStatement(),
                ReturnStatement(ParseName(resultVariableName))
            )
            .AddModifiers(PublicKeyword());

        return new MethodBuilder(method);
    }

    public MethodDeclarationSyntax GetMethod() => _methodDeclaration;
}