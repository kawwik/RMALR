using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RMALR.Lexis.Lexers;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static RMALR.Syntax.SyntaxFactory;

namespace RMALR.Syntax.Parser.Builders;

public class ParserBuilder
{
    private readonly CompilationUnitSyntax _compilationUnit;
    private ClassDeclarationSyntax _parserClass;

    public ParserBuilder(string grammarName)
    {
        _compilationUnit = CompilationUnit().AddUsings(
            UsingDirective(ParseName("System.Numerics")),
            UsingDirective(ParseName("RMALR.Lexis.Lexers")),
            UsingDirective(ParseName("RMALR.Syntax.Nodes")),
            UsingDirective(ParseName("RMALR.Syntax.Parser")),
            UsingDirective(ParseName("RMALR.Exceptions")));
        
        var parserName = $"{grammarName}Parser";

        var constructor = ConstructorDeclaration(parserName)
            .AddParameterListParameters(
                Parameter(Identifier("tokenStream"))
                    .WithType(ParseTypeName(nameof(ITokenStream))))
            .WithInitializer(ConstructorInitializer(SyntaxKind.BaseConstructorInitializer)
                .AddArgumentListArguments(Argument(IdentifierName("tokenStream"))))
            .WithBody(Block())
            .AddModifiers(PublicKeyword());

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

    public override string ToString() => GetCompilationUnit().NormalizeWhitespace().ToString();
}