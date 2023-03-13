using RMALR.Lexis;
using RMALR.RecognizerGenerators;
using RMALR.Syntax.Parser;

var lexerGenerator = new LexerGenerator();
var parserGenerator = new ParserGenerator();

var recognizerGenerator = new RecognizerGenerator(lexerGenerator, parserGenerator);

string workingDirectory = Environment.CurrentDirectory;
var projectDir = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;

recognizerGenerator.Generate(
    Path.Combine(projectDir, "pythonLogic.rma") ,
    Path.Combine(projectDir, "Generated"),
    "PythonLogic");

// var tokenizer = new Lab2Lexer();
// var tokenStream = tokenizer.GetTokenStream("((a or b) and c)");
// var parser = new Lab2Parser(tokenStream);
// var tree = parser.ReadStartNode();
// var graphvizCode = new GraphVizCodeGenerator(squash: true, hideEmptyChildren: true).GenerateFromTree(tree);
// Console.WriteLine(graphvizCode);
