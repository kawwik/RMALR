using Lab4.Generated;

namespace Lab4.Lexis;

public interface ILexerGenerator
{
    string CreateLexer(RMALRParser.StartContext tree);
}