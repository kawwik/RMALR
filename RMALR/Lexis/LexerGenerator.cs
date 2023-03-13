using Lab4.Generated;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace RMALR.Lexis;

public class LexerGenerator : ILexerGenerator
{
    public SourceText Generate(RMALR_parser.StartContext tree, string grammarName)
    {
        var lexisVisitor = new LexisVisitor();
        var result = lexisVisitor.ParseLexer(tree, $"{grammarName}Lexer");

        return result.NormalizeWhitespace().GetText();
    }
}