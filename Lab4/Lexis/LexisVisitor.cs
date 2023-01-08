using Lab4.Generated;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Lab4.Syntax.SyntaxFactory;

namespace Lab4.Lexis;

public class LexisVisitor : RMALR_parserBaseVisitor<SyntaxNode>
{
    public SyntaxNode ParseLexer(RMALR_parser.StartContext startContext, string parserName)
    {
        var compilationUnit = CompilationUnit()
            .AddUsings(
                UsingDirective(ParseName("Lab4.Lexis.Lexers")),
                UsingDirective(ParseName("Lab4.Lexis.Matchers"))
            )
            .AddMembers(
                FileScopedNamespaceDeclaration(ParseName("Lab4.Lexis.Examples"))
            );

        var constructorBody = VisitStart(startContext);
        var lexerConstructor = ConstructorDeclaration(parserName)
            .WithBody(constructorBody)
            .AddModifiers(PublicKeyword());

        var lexerClass = ClassDeclaration(parserName)
            .AddBaseListTypes(SimpleBaseType(ParseName("TokenizerBase")))
            .AddMembers(lexerConstructor)
            .AddModifiers(PublicKeyword());
        
        
        return compilationUnit.AddMembers(lexerClass);
    }
    
    public override BlockSyntax VisitStart(RMALR_parser.StartContext context)
    {
        var tokenNames = context.token().Select(x => x.TOKEN_NAME().Symbol.Text).ToArray();

        var matcherDeclarations =
            context.token().Select(VisitToken)
                .Cast<VariableDeclarationSyntax>()
                .Select(LocalDeclarationStatement)
                .Cast<StatementSyntax>()
                .ToArray();

        var addMatcherStatements = tokenNames
            .Select(x => MemberInvocationStatement("Matchers", "Add", Argument(IdentifierName(x))))
            .Cast<StatementSyntax>()
            .ToArray();

        var constructorBody = Block(matcherDeclarations.Concat(addMatcherStatements));

        return constructorBody;
    }

    public override SyntaxNode VisitToken(RMALR_parser.TokenContext context)
    {
        var tokenName = context.TOKEN_NAME().Symbol.Text;

        var arguments = new List<ArgumentSyntax>
        {
            Argument(StringLiteralExpression(tokenName))
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

        var matcherCreation = ObjectCreationExpression(ParseTypeName("TokenMatcher"))
            .AddArgumentListArguments(arguments.ToArray());

        if (context.lexer_rule() is not null)
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