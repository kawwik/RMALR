using Lab4.Generated;

namespace Lab4.Lexis;

public interface ILexerGenerator
{
    string Generate(RMALRParser.StartContext tree, string grammarName);
}