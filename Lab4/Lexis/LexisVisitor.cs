﻿using Lab4.Generated.Lexis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Lab4.SyntaxFactory;

namespace Lab4.Lexis;

public class LexisVisitor : lexisBaseVisitor<SyntaxNode>
{
    public override SyntaxNode VisitStart(lexisParser.StartContext context)
    {
        var tokenNames = context.token().Select(x => x.TOKEN_NAME().Symbol.Text).ToArray();

        var compilationUnit = CompilationUnit()
            .AddUsings(
                UsingDirective(ParseName("Lab4.Lexis.Lexers")),
                UsingDirective(ParseName("Lab4.Lexis.Matchers"))
            )
            .AddMembers(
                FileScopedNamespaceDeclaration(ParseName("Lab4.Lexis.Examples")),
                EnumDeclaration("TokenType")
                    .AddMembers(tokenNames.Select(EnumMemberDeclaration).ToArray())
                    .AddModifiers(PublicKeyword())
            );

        var matcherDeclarations =
            context.token().Select(VisitToken)
                .Cast<VariableDeclarationSyntax>()
                .Select(LocalDeclarationStatement)
                .Cast<StatementSyntax>()
                .ToArray();

        var addMatcherStatements = tokenNames
            .Select(x => InvocationStatement("Matchers", "Add", Argument(IdentifierName(x))))
            .Cast<StatementSyntax>()
            .ToArray();

        var lexerConstructor = ConstructorDeclaration("ExampleTokenizer")
            .AddBodyStatements(matcherDeclarations)
            .AddBodyStatements(addMatcherStatements)
            .AddModifiers(PublicKeyword());

        var lexerClass = ClassDeclaration("ExampleTokenizer")
            .AddBaseListTypes(SimpleBaseType(ParseName("TokenizerBase")))
            .AddMembers(lexerConstructor)
            .AddModifiers(PublicKeyword());

        return compilationUnit.AddMembers(lexerClass);
    }

    public override SyntaxNode VisitToken(lexisParser.TokenContext context)
    {
        var tokenName = context.TOKEN_NAME().Symbol.Text;

        var arguments = new List<ArgumentSyntax>
        {
            Argument(MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName("TokenType"),
                IdentifierName(tokenName)))
        };

        foreach (var pattern in context.patterns().pattern())
        {
            var argument = (pattern.TOKEN_NAME(), pattern.REGEXP()) switch
            {
                ({ }, null) => Argument(ParseName(pattern.TOKEN_NAME().Symbol.Text)),
                (null, { }) => Argument(
                    ObjectCreationExpression(ParseTypeName("RegexMatcher"))
                        .AddArgumentListArguments(
                            Argument(StringLiteralExpression(pattern.REGEXP().GetText().Trim('"')))))
            };

            arguments.Add(argument);
        }

        var matcherCreation = ObjectCreationExpression(ParseTypeName("TokenMatcher<TokenType>"))
            .AddArgumentListArguments(arguments.ToArray());

        if (context.rule().Any())
        {
            matcherCreation = ObjectCreationExpression(ParseTypeName("SkipMatcher"))
                .AddArgumentListArguments(Argument(matcherCreation));
        }

        return VariableDeclaration(ParseTypeName("var"))
            .AddVariables(
                VariableDeclarator(tokenName)
                    .WithInitializer(EqualsValueClause(matcherCreation))
            );
    }
}