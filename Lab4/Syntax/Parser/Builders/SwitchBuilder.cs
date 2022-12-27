﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Lab4.SyntaxFactory;

namespace Lab4.Syntax.Parser.Builders;

public class SwitchBuilder
{
    private SwitchStatementSyntax _switchStatement;

    public SwitchBuilder()
    {
        var expression = MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            IdentifierName("CurrentToken"),
            IdentifierName("Type"));
        
        _switchStatement = SwitchStatement(expression);
    }

    public SwitchStatementSyntax GetSwitchStatement() => _switchStatement;

    public void AddCase(SwitchCaseBuilder switchCaseBuilder)
    {
        _switchStatement = _switchStatement.AddSections(switchCaseBuilder.GetSection());
    }

    public void AddDefaultThrow()
    {
        var section = SwitchCaseBuilder.BuildDefaultCase();
        section.AddThrowStatement(nameof(InvalidOperationException), "Неожиданный токен");

        _switchStatement = _switchStatement.AddSections(section.GetSection());
    }
}