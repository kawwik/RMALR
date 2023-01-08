using Lab4.Generated;

namespace Lab4.Lexis;

public interface ILexerGenerator
{
    string Generate(RMALR_parser.StartContext tree, string grammarName);
}