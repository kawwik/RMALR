using Lab4.Generated;
using Microsoft.CodeAnalysis;

namespace Lab4.Lexis;

public class LexerGenerator : ILexerGenerator
{
    public string CreateLexer(RMALRParser.StartContext tree)
    {
        var lexisVisitor = new LexisVisitor();
        var result = lexisVisitor.Visit(tree);

        return result.NormalizeWhitespace().ToString();
    }
}