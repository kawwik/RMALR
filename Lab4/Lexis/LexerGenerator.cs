using Antlr4.Runtime;
using Lab4.Generated.Lexis;
using Microsoft.CodeAnalysis;

namespace Lab4.Lexis;

public class LexerGenerator : ILexerGenerator
{
    public string CreateLexerFromGrammar(string lexisCode)
    {
        var lexer = new lexisLexer(CharStreams.fromString(lexisCode));
        var parser = new lexisParser(new CommonTokenStream(lexer));

        var lexisVisitor = new LexisVisitor();
        var result = lexisVisitor.Visit(parser.start());

        return result.NormalizeWhitespace().ToString();
    }
}