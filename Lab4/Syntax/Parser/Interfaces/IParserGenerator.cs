using Lab4.Generated;

namespace Lab4.Syntax.Parser.Interfaces;

public interface IParserGenerator
{
    string Generate(RMALRParser.StartContext tree, string grammarName);
}