using Antlr4.Runtime;
using Lab4.Generated;
using Lab4.Lexis;
using Lab4.Syntax;

namespace Lab4.RecognizerGenerators;

public class RecognizerGenerator
{
    private readonly ILexerGenerator _lexerGenerator;

    public RecognizerGenerator(ILexerGenerator lexerGenerator)
    {
        _lexerGenerator = lexerGenerator;
    }

    public void Generate(string inputFile, string outputDirectory)
    {
        var inputText = File.ReadAllText(inputFile);
        
        var lexer = new RMALRLexer(CharStreams.fromString(inputText));
        var parser = new RMALRParser(new CommonTokenStream(lexer));

        var tree = parser.start(); 
        GenerateLexer(tree, outputDirectory + "/Lexer.cs");
        GenerateParser(tree);
    }

    private void GenerateLexer(RMALRParser.StartContext tree, string outputFile)
    {
        var lexerCode = _lexerGenerator.CreateLexer(tree);
        File.WriteAllText(outputFile, lexerCode);
    }

    private void GenerateParser(RMALRParser.StartContext tree)
    {
        var grammarVisitor = new GrammarVisitor();
        var rules = grammarVisitor.GetAllRules(tree);
    }
}