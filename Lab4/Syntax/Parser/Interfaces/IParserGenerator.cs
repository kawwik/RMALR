using Lab4.Generated;
using Microsoft.CodeAnalysis.Text;

namespace Lab4.Syntax.Parser.Interfaces;

public interface IParserGenerator
{
    SourceText Generate(RMALR_parser.StartContext tree, string grammarName);
}