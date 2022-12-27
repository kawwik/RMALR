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
        _childAddInvocation = InvocationExpression(
            MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("result"),
                IdentifierName("AddChildren")));
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

    public SwitchSectionSyntax GetSection()
    {
        var section = _switchSection;
        if (_childAddInvocation is not null)
            section = section.AddStatements(ExpressionStatement(_childAddInvocation));

        return section.AddStatements(BreakStatement());
    }

    public void AddTerminalNodeReading(string terminalType)
    {
        var invocation = InvocationExpression(IdentifierName("ReadTerminal"))
            .AddArgumentListArguments(Argument(StringLiteralExpression(terminalType)));

        AddChildAdding(invocation);
    }

    public void AddNonTerminalNodeReading(string nonTerminalType)
    {
        var invocation = InvocationExpression(IdentifierName($"Read{nonTerminalType}Node"));

        AddChildAdding(invocation);
    }

    private void AddChildAdding(ExpressionSyntax childExpression)
    {
        _childAddInvocation = _childAddInvocation?.AddArgumentListArguments(Argument(childExpression));
    }

    public void AddThrowStatement(string exceptionName, string message)
    {
        var throwStatement = ThrowStatement(
            ObjectCreationExpression(ParseTypeName(exceptionName))
                .AddArgumentListArguments(Argument(StringLiteralExpression(message))));

        _switchSection = _switchSection.AddStatements(throwStatement);
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