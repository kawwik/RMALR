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

        switchBuilder.AddCase(BuildCase());
        switchBuilder.AddDefaultThrow();
        
        var methodBuilder = MethodBuilder.BuildParserMethod(rule.Name, switchBuilder);
        return methodBuilder;
    }

    private SwitchCaseBuilder BuildCase()
    {
        var caseBuilder = new SwitchCaseBuilder();
        caseBuilder.AddLabels("Some1", "Some2", "Some3");
        caseBuilder.AddTerminalNodeReading("XorNode");
        caseBuilder.AddNonTerminalNodeReading("Zhopa");

        return caseBuilder;
    }
}