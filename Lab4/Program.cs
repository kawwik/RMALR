using Lab4.Lexis;
using Lab4.Lexis.Examples;
using Lab4.RecognizerGenerators;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

var lexerGenerator = new LexerGenerator();
var recognizerGenerator = new RecognizerGenerator(lexerGenerator);
recognizerGenerator.Generate(
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\input.rma",
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\GeneratedExample");

var tokenizer = new ExampleTokenizer();
var tokenStream = tokenizer.GetTokenStream("word   worda");

// foreach (var token in tokenStream)
// {
//     var valueToken = token as Token<TokenType>;
//     Console.WriteLine(valueToken?.Value);
// }
//
//
// Console.WriteLine(tokenStream.Count());

Literal("hhh");