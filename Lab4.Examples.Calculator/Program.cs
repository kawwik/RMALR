using Lab4.Lexis;
using Lab4.Lexis.Examples;
using Lab4.RecognizerGenerators;
using Lab4.Syntax.Parser;

var lexerGenerator = new LexerGenerator();
var parserGenerator = new ParserGenerator();

var recognizerGenerator = new RecognizerGenerator(lexerGenerator, parserGenerator);

recognizerGenerator.Generate(
    @"C:\Users\79148\RiderProjects\Lab4\Lab4.Examples.Calculator\calculator.rma",
    @"C:\Users\79148\RiderProjects\Lab4\Lab4.Examples.Calculator\Generated",
    "Calculator");


var tokenizer = new CalculatorLexer();
var tokenStream = tokenizer.GetTokenStream("(5 + 2 * 8 * (3 + 1)) / 23");
var parser = new CalculatorParser(tokenStream);
parser.ReadStartNode();