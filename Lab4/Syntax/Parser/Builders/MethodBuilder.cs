using Lab4.Syntax.Nodes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Lab4.SyntaxFactory;

namespace Lab4.Syntax.Parser.Builders;

public class MethodBuilder
{
    private const string _resultVariableName = "result";
    private MethodDeclarationSyntax _methodDeclaration;

    public MethodBuilder(string returnType, string methodName)
    {
        _methodDeclaration = MethodDeclaration(ParseTypeName(returnType), methodName);
    }

    private MethodBuilder(MethodDeclarationSyntax methodDeclaration) => _methodDeclaration = methodDeclaration;

    public static MethodBuilder BuildParserMethod(string nodeType)
    {
        var method = MethodDeclaration(ParseTypeName(nameof(NonTerminalNode)), $"Read{nodeType}Node")
            .AddBodyStatements(
                LocalDeclarationStatement(
                    VariableDeclarationWithCreation(
                        _resultVariableName,
                        ParseTypeName(nameof(NonTerminalNode)),
                        Argument(StringLiteralExpression(nodeType))))
            )
            .AddModifiers(PublicKeyword());

        return new MethodBuilder(method);
    }

    public void AddParameters(params string[] parameterNames)
    {
        var parameters = parameterNames
            .Select(Identifier)
            .Select(x => Parameter(x).WithType(ParseTypeName("dynamic")))
            .ToArray();

        _methodDeclaration = _methodDeclaration.AddParameterListParameters(parameters);
    }

    public void AddBodyStatements(BodyBuilder bodyBuilder)
    {
        _methodDeclaration = _methodDeclaration.AddBodyStatements(bodyBuilder.GetStatements());
    }

    public MethodDeclarationSyntax GetMethod() => _methodDeclaration.AddBodyStatements(
        ReturnStatement(ParseName(_resultVariableName)));
}