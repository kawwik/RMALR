using Lab4.Syntax.Interfaces;
using Lab4.Syntax.Parser.Builders;
using Lab4.Syntax.Rules;

namespace Lab4.Syntax.Parser;

public class ParserGenerator : IParserGenerator
{
    public string Generate(IReadOnlyCollection<NamedRule> rules)
    {
        var parserBuilder = new ParserBuilder("Example");

        foreach (var rule in rules)
        {
            parserBuilder.AddMethod(BuildRuleReadingMethod(rule));
        }

        return parserBuilder.ToString();
    }

    private MethodBuilder BuildRuleReadingMethod(NamedRule rule)
    {
        var switchBuilder = new SwitchBuilder();

        foreach (var option in rule.Options)
        {
            switchBuilder.AddCase(BuildCase(option));
        }

        switchBuilder.AddDefaultThrow();
        
        var methodBuilder = MethodBuilder.BuildParserMethod(rule.Name, switchBuilder);
        return methodBuilder;
    }

    private SwitchCaseBuilder BuildCase(CompositeRule option)
    {
        var caseBuilder = new SwitchCaseBuilder();
        
        var first = option.First().ToArray();
        caseBuilder.AddLabels(first);

        foreach (var rule in option.Rules)
        {
            switch (rule)
            {
                case NamedRule namedRule:
                    caseBuilder.AddNonTerminalNodeReading(namedRule.Name);
                    break;
                case TokenRule tokenRule:
                    caseBuilder.AddTerminalNodeReading(tokenRule.TokenType);
                    break;
            }
        }

        return caseBuilder;
    }
}