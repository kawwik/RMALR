using Lab4.Generated;
using Lab4.Syntax.Rules;

namespace Lab4.Syntax;

public class GrammarVisitor : RMALRBaseVisitor<Rule>
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

        namedRule.Rule = VisitRule_body(context.rule_body());

        return namedRule;
    }

    public override Rule VisitRule_body(RMALRParser.Rule_bodyContext context)
    {
        var options = context.rule_option()
            .Select(VisitRule_option)
            .ToArray();

        return options.Length == 1
            ? options.First()
            : new OptionsRule(options);
    }

    public override Rule VisitRule_option(RMALRParser.Rule_optionContext context)
    {
        var ruleParts = context.rule_part()
            .Select(VisitRule_part)
            .ToArray();

        return ruleParts.Length == 1 
            ? ruleParts.First()
            : new CompositeRule(ruleParts);
    }

    public override Rule VisitRule_part(RMALRParser.Rule_partContext context)
    {
        if (context.TOKEN_NAME() is { } tokenName)
            return new TokenRule(tokenName.GetText());

        if (context.RULE_NAME() is { } ruleName)
            return GetOrCreateRule(ruleName.GetText());

        if (context.rule_body() is { } ruleBody)
            return VisitRule_body(ruleBody); 

        var rulePart = VisitRule_part(context.rule_part());
        if (context.QUESTION_MARK() is not null)
        {
            if (rulePart is not OptionsRule optionsRule) 
                return new OptionsRule(rulePart, new EmptyRule());
            
            var options = optionsRule.Options
                .UnionBy(new[] { new EmptyRule() }, rule => rule.GetType())
                .ToArray();

            return new OptionsRule(options);

        }
        
        throw new NotImplementedException("Знаки *, + не реализованы");
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