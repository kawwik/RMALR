using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lab4.Syntax.Parser.Builders;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static SyntaxFactory;

public class SwitchCaseBuilder
{
    private SwitchSectionSyntax _switchSection;
    private InvocationExpressionSyntax? _childAddInvocation;

    public SwitchCaseBuilder()
    {
        _switchSection = SwitchSection();
        _childAddInvocation = BuildChildAddingInvocation();
    }

    private SwitchCaseBuilder(SwitchSectionSyntax section, InvocationExpressionSyntax? childAddInvocation)
    {
        _switchSection = section;
        _childAddInvocation = childAddInvocation;
    }

    public static SwitchCaseBuilder BuildDefaultCase()
    {
        return new SwitchCaseBuilder(SwitchSection().AddLabels(DefaultSwitchLabel()), null);
    }

    public SwitchSectionSyntax GetSection() => _switchSection.AddStatements(BreakStatement());

    public void AddTerminalNodeReading(string terminalType)
    {
        var invocation = InvocationExpression(IdentifierName("ReadTerminal"))
            .AddArgumentListArguments(Argument(StringLiteralExpression(terminalType)));

        PushChildAdding(invocation);
    }

    public void AddNonTerminalNodeReading(string nonTerminalType)
    {
        var invocation = InvocationExpression(IdentifierName($"Read{nonTerminalType}Node"));

        PushChildAdding(invocation);
    }

    public void AddStatement(StatementSyntax statement)
    {
        PopChildAddingStatement();
        
        _switchSection = _switchSection.AddStatements(statement);
    }

    private void PushChildAdding(ExpressionSyntax childExpression)
    {
        _childAddInvocation ??= BuildChildAddingInvocation();
        _childAddInvocation = _childAddInvocation.AddArgumentListArguments(Argument(childExpression));
    }

    private static InvocationExpressionSyntax BuildChildAddingInvocation()
    {
        return InvocationExpression(
            MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("result"),
                IdentifierName("AddChildren")));
    }

    public void PopChildAddingStatement()
    {
        if (_childAddInvocation is not null && _childAddInvocation.ArgumentList.Arguments.Any())
            _switchSection = _switchSection.AddStatements(ExpressionStatement(_childAddInvocation));

        _childAddInvocation = null;
    }

    public void AddThrowStatement(string exceptionName, string message)
    {
        var throwStatement = ThrowStatement(
            ObjectCreationExpression(ParseTypeName(exceptionName))
                .AddArgumentListArguments(Argument(StringLiteralExpression(message))));

        AddStatement(throwStatement);
    }

    public void AddLabels(params string[] labels)
    {
        var constPatterns = labels
            .Select(StringLiteralExpression)
            .Select(ConstantPattern)
            .ToList();

        if (constPatterns.Count == 1)
        {
            var label = CasePatternSwitchLabel(constPatterns.Single(), Token(SyntaxKind.ColonToken));
            _switchSection = _switchSection.AddLabels(label);
            return;
        }

        var orPattern = BinaryPattern(SyntaxKind.OrPattern, constPatterns[0], constPatterns[1]);

        for (int i = 2; i < constPatterns.Count; i++)
        {
            orPattern = BinaryPattern(SyntaxKind.OrPattern, orPattern, constPatterns[i]);
        }

        _switchSection = _switchSection.AddLabels(CasePatternSwitchLabel(orPattern, Token(SyntaxKind.ColonToken)));
    }
}