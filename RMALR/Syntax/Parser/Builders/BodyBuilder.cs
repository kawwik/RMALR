﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static RMALR.Syntax.SyntaxFactory;

namespace RMALR.Syntax.Parser.Builders;

public class BodyBuilder
{
    private BlockSyntax _block;
    private InvocationExpressionSyntax? _childAddInvocation;

    public BodyBuilder()
    {
        _block = Block();
    }
    
    public void AddTerminalNodeReading(string terminalType)
    {
        var invocation = InvocationExpression(IdentifierName("ReadTerminal"))
            .AddArgumentListArguments(Argument(StringLiteralExpression(terminalType)));

        PushChildAdding(invocation);
    }
    
    public void AddNonTerminalNodeReading(string nonTerminalType, IReadOnlyCollection<ExpressionSyntax> argumentExpressions)
    {
        var arguments = argumentExpressions.Select(Argument).ToArray();
        var invocation = InvocationExpression(IdentifierName($"Read{nonTerminalType}Node"))
            .AddArgumentListArguments(arguments);
        
        PushChildAdding(invocation);
    }

    public void PopChildAddingStatement()
    {
        if (_childAddInvocation is not null)
            _block = _block.AddStatements(ExpressionStatement(_childAddInvocation));

        _childAddInvocation = null;
    }
    
    public void AddStatements(params StatementSyntax[] statements)
    {
        _block = _block.AddStatements(statements);
    }

    private void PushChildAdding(ExpressionSyntax childExpression)
    {
        _childAddInvocation ??= BuildChildAddingInvocation().AddArgumentListArguments(Argument(childExpression));
    }
    
    private static InvocationExpressionSyntax BuildChildAddingInvocation()
    {
        return InvocationExpression(
            MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("result"),
                IdentifierName("AddChildren")));
    }

    public StatementSyntax[] GetStatements() => _block.Statements.ToArray();
}