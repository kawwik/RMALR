using Lab4.Generated;
using Microsoft.CodeAnalysis.Text;

namespace Lab4.Lexis;

public interface ILexerGenerator
{
    SourceText Generate(RMALR_parser.StartContext tree, string grammarName);
}