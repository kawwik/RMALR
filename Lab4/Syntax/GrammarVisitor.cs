using Lab4.Generated;
using Lab4.Syntax.Rules;

namespace Lab4.Syntax;

public class GrammarVisitor : RMALRBaseVisitor<RuleBase>
{
    private readonly Dictionary<string, NamedRule?> _nameToRuleMapper = new();

    public List<NamedRule> GetAllRules(RMALRParser.StartContext context)
    {
        _nameToRuleMapper.Clear();
        return context.rule_definition()
            .Select(VisitRule_definition)
            .ToList();
    }

    public override NamedRule VisitRule_definition(RMALRParser.Rule_definitionContext context)
    {
        var namedRule = GetOrCreateRule(context.RULE_NAME().GetText());
        namedRule.Options = VisitRuleBody(context.rule_body());
        
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

        if (context.RULE_NAME() is not null)
            return GetOrCreateRule(context.RULE_NAME().GetText());

        if (context.rule_body() is not null)
            return new CompositeRule(VisitRuleBody(context.rule_body()));

        throw new NotImplementedException("Знаки ?, *, + не реализованы");
    }

    private CompositeRule[] VisitRuleBody(RMALRParser.Rule_bodyContext context)
    {
        return context.rule_option()
            .Select(VisitRule_option)
            .ToArray();
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