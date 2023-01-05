using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lab4.Syntax.Parser.Builders;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static SyntaxFactory;

public class SwitchCaseBuilder
{
    private SwitchSectionSyntax _switchSection;

    public SwitchCaseBuilder()
    {
        _switchSection = SwitchSection();
    }

    private SwitchCaseBuilder(SwitchSectionSyntax section)
    {
        _switchSection = section;
    }

    public static SwitchCaseBuilder BuildDefaultCase()
    {
        return new SwitchCaseBuilder(SwitchSection().AddLabels(DefaultSwitchLabel()));
    }

    public SwitchSectionSyntax GetSection() => _switchSection.AddStatements(BreakStatement());
    
    public void AddStatements(params StatementSyntax[] statements)
    {
        _switchSection = _switchSection.AddStatements(statements);
    }
    
    public void AddStatements(BodyBuilder bodyBuilder)
    {
        _switchSection = _switchSection.AddStatements(bodyBuilder.GetStatements());
    }

    public void AddThrowStatement(string exceptionName, string message)
    {
        var throwStatement = ThrowStatement(
            ObjectCreationExpression(ParseTypeName(exceptionName))
                .AddArgumentListArguments(Argument(StringLiteralExpression(message))));

        AddStatements(throwStatement);
    }

    public void AddLabels(params string[] labels)
    {
        var constPatterns = labels
            .Select(StringLiteralExpression)
            .Select(ConstantPattern)
            .ToList();

        if (constPatterns.Count == 0)
            throw new ArgumentException("Пустая коллекция лейблов");

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