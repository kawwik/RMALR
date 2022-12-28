using Lab4.Lexis;
using Lab4.RecognizerGenerators;
using Lab4.Syntax.Parser;

var lexerGenerator = new LexerGenerator();
var parserGenerator = new ParserGenerator();

var recognizerGenerator = new RecognizerGenerator(lexerGenerator, parserGenerator);

recognizerGenerator.Generate(
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\lab2.rma",
    @"C:\Users\79148\RiderProjects\Lab4\Lab4\GeneratedExample",
    "Lab2");