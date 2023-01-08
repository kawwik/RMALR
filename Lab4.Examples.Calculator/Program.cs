using Lab4.Examples.Calculator.Generated;
using Lab4.Lexis;
using Lab4.RecognizerGenerators;
using Lab4.Syntax.Parser;

var lexerGenerator = new LexerGenerator();
var parserGenerator = new ParserGenerator();

var recognizerGenerator = new RecognizerGenerator(lexerGenerator, parserGenerator);

recognizerGenerator.Generate(
    @"C:\Users\79148\RiderProjects\Lab4\Lab4.Examples.Calculator\attributes.rma",
    @"C:\Users\79148\RiderProjects\Lab4\Lab4.Examples.Calculator\Generated",
    "Attributes");


var tokenizer = new AttributesLexer();
var tokenStream = tokenizer.GetTokenStream("xor or");
var parser = new AttributesParser(tokenStream);
parser.ReadStartNode();