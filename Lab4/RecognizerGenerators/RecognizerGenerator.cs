using Antlr4.Runtime;
using Lab4.Generated;
using Lab4.Lexis;
using Lab4.Syntax.Parser.Interfaces;

namespace Lab4.RecognizerGenerators;

public class RecognizerGenerator
{
    private readonly ILexerGenerator _lexerGenerator;
    private readonly IParserGenerator _parserGenerator;

    public RecognizerGenerator(
        ILexerGenerator lexerGenerator,
        IParserGenerator parserGenerator)
    {
        _lexerGenerator = lexerGenerator;
        _parserGenerator = parserGenerator;
    }

    public void Generate(string inputFile, string outputDirectory, string grammarName)
    {
        var inputText = File.ReadAllText(inputFile);
        
        var lexer = new RMALRLexer(CharStreams.fromString(inputText));
        var parser = new RMALRParser(new CommonTokenStream(lexer));

        var tree = parser.start(); 
        GenerateLexer(tree, outputDirectory + $"/{grammarName}Lexer.cs", grammarName);
        GenerateParser(tree, outputDirectory + $"/{grammarName}Parser.cs", grammarName);
    }

    private void GenerateLexer(RMALRParser.StartContext tree, string outputFile, string grammarName)
    {
        var lexerCode = _lexerGenerator.Generate(tree, grammarName);
        File.WriteAllText(outputFile, lexerCode);
    }

    private void GenerateParser(RMALRParser.StartContext tree, string outputFile, string grammarName)
    {
        var parserCode = _parserGenerator.Generate(tree, grammarName);
        File.WriteAllText(outputFile, parserCode);
    }
}