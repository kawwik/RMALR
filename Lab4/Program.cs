using Lab4.Lexis;
using Lab4.Lexis.Examples;
using Lab4.RecognizerGenerators;
using Lab4.Syntax.Parser.Builders;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

var lexerGenerator = new LexerGenerator();
var recognizerGenerator = new RecognizerGenerator(lexerGenerator);
recognizerGenerator.Generate(
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\input.rma",
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\GeneratedExample");

var tokenizer = new ExampleTokenizer();
var tokenStream = tokenizer.GetTokenStream("word   worda");

var caseBuilder = new SwitchCaseBuilder();
caseBuilder.AddLabels("Some1", "Some2", "Some3");
caseBuilder.AddTerminalNodeReading("XorNode");
caseBuilder.AddNonTerminalNodeReading("Zhopa");
var switchBuilder = new SwitchBuilder(
    MemberAccessExpression(
        SyntaxKind.SimpleMemberAccessExpression,
        IdentifierName("CurrentToken"),
        IdentifierName("Type")));
switchBuilder.AddCase(caseBuilder);
switchBuilder.AddDefaultThrow();
var methodBuilder = MethodBuilder.BuildParserMethod("And", switchBuilder.GetSwitchStatement());

var parserBuilder = new ParserBuilder("Example");
parserBuilder.AddMethod(methodBuilder);
Console.WriteLine(parserBuilder.GetCompilationUnit().NormalizeWhitespace());

// foreach (var token in tokenStream)
// {
//     var valueToken = token as Token<TokenType>;
//     Console.WriteLine(valueToken?.Value);
// }
//
//
// Console.WriteLine(tokenStream.Count());

Literal("hhh");