using Lab4.Generated;
using Microsoft.CodeAnalysis;

namespace Lab4.Lexis;

public class LexerGenerator : ILexerGenerator
{
    public string Generate(RMALR_parser.StartContext tree, string grammarName)
    {
        var lexisVisitor = new LexisVisitor();
        var result = lexisVisitor.ParseLexer(tree, $"{grammarName}Lexer");

        return result.NormalizeWhitespace().ToString();
    }
}