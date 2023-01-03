using Lab4.Generated;
using Lab4.Lexis.Tokens;
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
        var switchBuilder = BuildSwitch(rule);

        var methodBuilder = MethodBuilder.BuildParserMethod(rule.Name.Capitalize(), switchBuilder);
        return methodBuilder;
    }

    private SwitchBuilder BuildSwitch(NamedRule namedRule)
    {
        var switchBuilder = new SwitchBuilder();

        foreach (var option in namedRule.Options)
        {
            
            switchBuilder.AddCase(BuildCase(option.Rules, option.First()));
        }

        switchBuilder.AddDefaultThrow();
        return switchBuilder;
    }

    private SwitchBuilder BuildSwitch(CompositeRule compositeRule)
    {
        var switchBuilder = new SwitchBuilder();
        
        switchBuilder.AddCase(BuildCase(compositeRule.Rules, compositeRule.First()));
        switchBuilder.AddDefaultThrow();

        return switchBuilder;
    }

    private SwitchBuilder BuildSwitch(OptionsRule optionsRule)
    {
        var switchBuilder = new SwitchBuilder();

        foreach (var option in optionsRule.Options)
        {
            if (option is EmptyRule)
                continue;

            var first = option.First();
            first.Remove(EmptyToken.TokenType);

            switchBuilder.AddCase(BuildCase(new []{option}, first));
        }
    
        return switchBuilder;
    }

    private SwitchCaseBuilder BuildCase(IReadOnlyCollection<Rule> rules, HashSet<string> first)
    {
        if (!first.Any())
            throw new ArgumentException("Множество FIRST не может быть пустым");
        
        var caseBuilder = new SwitchCaseBuilder();
        caseBuilder.AddLabels(first.ToArray());
  
        foreach (var rule in rules) 
            AddRule(caseBuilder, rule);

        caseBuilder.PopChildAddingStatement();
        return caseBuilder;
    }

    private void AddRule(SwitchCaseBuilder caseBuilder, Rule rule)
    {
        switch (rule)
        {
            case EmptyRule:
                break;
            case NamedRule namedRule:
                caseBuilder.AddNonTerminalNodeReading(namedRule.Name.Capitalize());
                break;
            case TokenRule tokenRule:
                caseBuilder.AddTerminalNodeReading(tokenRule.TokenType);
                break;
            case CompositeRule compositeRule:
                caseBuilder.AddStatement(BuildSwitch(compositeRule).GetSwitchStatement());
                break;
            case OptionsRule optionsRule:
                caseBuilder.AddStatement(BuildSwitch(optionsRule).GetSwitchStatement());
                break;
            default:
                throw new NotImplementedException($"Тип правила {rule.GetType().Name} не поддерживается");
        }
    }
}