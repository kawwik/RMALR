using Lab4.Generated;
using Microsoft.CodeAnalysis.Text;

namespace RMALR.Lexis;

public interface ILexerGenerator
{
    SourceText Generate(RMALR_parser.StartContext tree, string grammarName);
}