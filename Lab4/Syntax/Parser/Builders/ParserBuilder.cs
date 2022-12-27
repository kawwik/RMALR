using Lab4.Lexis.Lexers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Lab4.SyntaxFactory;

namespace Lab4.Syntax.Parser.Builders;

public class ParserBuilder
{
    private readonly CompilationUnitSyntax _compilationUnit;
    private ClassDeclarationSyntax _parserClass;

    public ParserBuilder(string grammarName)
    {
        _compilationUnit = CompilationUnit().AddUsings(
            UsingDirective(ParseName("Lab4.Lexis.Lexers")),
            UsingDirective(ParseName("Lab4.Syntax.Nodes")),
            UsingDirective(ParseName("Lab4.Syntax.Parser")));
        
        var parserName = $"{grammarName}Parser";

        var constructor = ConstructorDeclaration(parserName)
            .AddParameterListParameters(
                Parameter(Identifier("tokenStream"))
                    .WithType(ParseTypeName(nameof(ITokenStream))))
            .WithInitializer(ConstructorInitializer(SyntaxKind.BaseConstructorInitializer)
                .AddArgumentListArguments(Argument(IdentifierName("tokenStream"))))
            .WithBody(Block());

        _parserClass = ClassDeclaration(parserName)
            .AddMembers(constructor)
            .AddModifiers(PublicKeyword())
            .AddBaseListTypes(SimpleBaseType(ParseTypeName(nameof(ParserBase))));
    }

    public CompilationUnitSyntax GetCompilationUnit() => _compilationUnit.AddMembers(_parserClass);

    public void AddMethod(MethodBuilder method)
    {
        _parserClass = _parserClass.AddMembers(method.GetMethod());
    }
}