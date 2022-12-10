using Lab4.Lexis;

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

        GenerateLexer(inputText, outputDirectory + "/Lexer.cs");
    }

    private void GenerateLexer(string grammar, string outputFile)
    {
        var lexerCode = _lexerGenerator.CreateLexerFromGrammar(grammar);
        File.WriteAllText(outputFile, lexerCode);
    }
}