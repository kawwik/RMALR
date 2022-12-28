using Lab4.Generated;
using Lab4.Syntax.Parser.Builders;
using Lab4.Syntax.Parser.Interfaces;
using Lab4.Syntax.Rules;
using Lab4.Utils;

namespace Lab4.Syntax.Parser;

public class ParserGenerator : IParserGenerator
{
    public string Generate(RMALRParser.StartContext tree, string grammarName)
    {
        var grammarVisitor = new GrammarVisitor();
        var rules = grammarVisitor.GetAllRules(tree);
        
        var parserBuilder = new ParserBuilder(grammarName);

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
        
        var methodBuilder = MethodBuilder.BuildParserMethod(rule.Name.Capitalize(), switchBuilder);
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
                    caseBuilder.AddNonTerminalNodeReading(namedRule.Name.Capitalize());
                    break;
                case TokenRule tokenRule:
                    caseBuilder.AddTerminalNodeReading(tokenRule.TokenType);
                    break;
                default:
                    throw new NotImplementedException($"Тип правила {rule.GetType().Name} не поддерживается");
            }
        }

        return caseBuilder;
    }
}