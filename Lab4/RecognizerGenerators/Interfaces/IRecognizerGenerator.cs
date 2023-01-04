namespace Lab4.RecognizerGenerators.Interfaces;

public interface IRecognizerGenerator
{
    void Generate(string inputFile, string outputDirectory, string grammarName);
}