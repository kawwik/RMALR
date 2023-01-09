using Lab4.Lexis;
using Lab4.Lexis.Examples;
using Lab4.RecognizerGenerators;
using Lab4.Syntax.Parser;
using Lab4.Visualization;

var lexerGenerator = new LexerGenerator();
var parserGenerator = new ParserGenerator();

var recognizerGenerator = new RecognizerGenerator(lexerGenerator, parserGenerator);

recognizerGenerator.Generate(
    @"C:\Users\79148\RiderProjects\Lab4\Lab4.Examples.Lab2\lab2.rma",
    @"C:\Users\79148\RiderProjects\Lab4\Lab4.Examples.Lab2\Generated",
    "Lab2");

var tokenizer = new Lab2Lexer();
var tokenStream = tokenizer.GetTokenStream("((a or b) and c)");
var parser = new Lab2Parser(tokenStream);
var tree = parser.ReadStartNode();
var graphvizCode = new GraphVizCodeGenerator(squash: true, hideEmptyChildren: true).GenerateFromTree(tree);
Console.WriteLine(graphvizCode);
