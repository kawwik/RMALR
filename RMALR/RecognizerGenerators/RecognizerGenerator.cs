using Antlr4.Runtime;
using Lab4.Generated;
using RMALR.Lexis;
using RMALR.RecognizerGenerators.Interfaces;
using RMALR.Syntax.Parser.Interfaces;

namespace RMALR.RecognizerGenerators;

public class RecognizerGenerator : IRecognizerGenerator
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
        
        var lexer = new RMALR_lexer(CharStreams.fromString(inputText));
        var parser = new RMALR_parser(new CommonTokenStream(lexer));

        var tree = parser.start(); 
        GenerateLexer(tree, outputDirectory + $"/{grammarName}Lexer.cs", grammarName);
        GenerateParser(tree, outputDirectory + $"/{grammarName}Parser.cs", grammarName);
    }

    private void GenerateLexer(RMALR_parser.StartContext tree, string outputFile, string grammarName)
    {
        var lexerCode = _lexerGenerator.Generate(tree, grammarName);
        
        using var writer = File.CreateText(outputFile);
        
        lexerCode.Write(writer);
    }

    private void GenerateParser(RMALR_parser.StartContext tree, string outputFile, string grammarName)
    {
        var parserCode = _parserGenerator.Generate(tree, grammarName);

        using var writer = File.CreateText(outputFile);
     
        parserCode.Write(writer);
    }
}