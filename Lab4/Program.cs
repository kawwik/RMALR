using Lab4.Lexis;
using Lab4.Lexis.Examples;
using Lab4.RecognizerGenerators;
using Lab4.Syntax.Parser;

var lexerGenerator = new LexerGenerator();
var parserGenerator = new ParserGenerator();

var recognizerGenerator = new RecognizerGenerator(lexerGenerator, parserGenerator);

recognizerGenerator.Generate(
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\lab2.rma",
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\GeneratedExample",
    "Lab2");


var tokenizer = new Lab2Lexer();
var tokenStream = tokenizer.GetTokenStream("a and not b");
var parser = new Lab2Parser(tokenStream);
var a = parser.ReadANode();
Console.WriteLine();