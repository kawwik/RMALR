using Lab4.Syntax.Rules;

namespace Lab4.Syntax.Interfaces;

public interface IParserGenerator
{
    string Generate(IReadOnlyCollection<NamedRule> rules, string grammarName);
}