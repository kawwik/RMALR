using Lab4.Generated;
using Lab4.Syntax.Rules;

namespace Lab4.Syntax;

public class GrammarVisitor : RMALRBaseVisitor<RuleBase>
{
    private readonly Dictionary<string, NamedRule?> _nameToRuleMapper = new();

    public List<NamedRule> GetAllRules(RMALRParser.StartContext context)
    {
        _nameToRuleMapper.Clear();
        return context.rule()
            .Select(VisitRule)
            .ToList();
    }

    public override NamedRule VisitRule(RMALRParser.RuleContext context)
    {
        var options = context.rule_option()
            .Select(VisitRule_option)
            .ToList();

        var namedRule = GetOrCreateRule(context.RULE_NAME().GetText());
        namedRule.Options = new OptionsRule(options);

        return namedRule;
    }

    public override CompositeRule VisitRule_option(RMALRParser.Rule_optionContext context)
    {
        var parts = context.rule_part()
            .Select(VisitRule_part)
            .ToList();

        return new CompositeRule(parts);
    }

    public override RuleBase VisitRule_part(RMALRParser.Rule_partContext context)
    {
        if (context.TOKEN_NAME() is not null)
            return new TokenRule(context.TOKEN_NAME().GetText());

        var ruleName = context.RULE_NAME().GetText();
        return GetOrCreateRule(ruleName);
    }

    private NamedRule GetOrCreateRule(string ruleName)
    {
        if (!_nameToRuleMapper.TryGetValue(ruleName, out var rule))
        {
            rule = new NamedRule(ruleName);
            _nameToRuleMapper.Add(ruleName, rule);
        }

        return rule!;
    }
}