using RMALR.Lexis;
using RMALR.RecognizerGenerators;
using RMALR.Syntax.Parser;

var lexerGenerator = new LexerGenerator();
var parserGenerator = new ParserGenerator();

var recognizerGenerator = new RecognizerGenerator(lexerGenerator, parserGenerator);

string workingDirectory = Environment.CurrentDirectory;
var projectDir = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;

recognizerGenerator.Generate(
    Path.Combine(projectDir, "calculator.rma") ,
    Path.Combine(projectDir, "Generated"),
    "PythonLogic");

// var tokenizer = new CalculatorLexer();
// var tokenStream = tokenizer.GetTokenStream("5 choose 3 choose 3");
// var parser = new CalculatorParser(tokenStream);
// parser.ReadStartNode();