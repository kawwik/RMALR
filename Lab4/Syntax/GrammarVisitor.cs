using Lab4.Generated;
using Lab4.Syntax.Rules;

namespace Lab4.Syntax;

public class GrammarVisitor : RMALRBaseVisitor<Rule>
{
    private readonly Dictionary<string, NamedRule> _ruleNameToRule = new();

    public List<NamedRule> GetAllRules(RMALRParser.StartContext context)
    {
        _ruleNameToRule.Clear();

        DefineRules(context);

        return context.rule_definition()
            .Select(VisitRule_definition)
            .ToList();
    }

    private void DefineRules(RMALRParser.StartContext context)
    {
        foreach (var ruleDefinition in context.rule_definition())
        {
            IReadOnlyCollection<string> inheritedAttributes = ruleDefinition.attribute_list() is null
                ? Array.Empty<string>()
                : VisitAttributeList(ruleDefinition.attribute_list());

            IReadOnlyCollection<string> synthesizedAttributes = ruleDefinition.returned_attributes() is null
                ? Array.Empty<string>()
                : VisitAttributeList(ruleDefinition.returned_attributes().attribute_list());

            var namedRule = new NamedRule(
                inheritedAttributes,
                synthesizedAttributes,
                ruleDefinition.IDENTIFIER().GetText());

            _ruleNameToRule.Add(namedRule.Name, namedRule);
        }
    }

    public override NamedRule VisitRule_definition(RMALRParser.Rule_definitionContext context)
    {
        var namedRule = _ruleNameToRule[context.IDENTIFIER().GetText()];
        var ruleBody = VisitRule_body(context.rule_body());
        namedRule.Payload = ruleBody;

        return namedRule;
    }


    private List<string> VisitAttributeList(RMALRParser.Attribute_listContext context)
    {
        return context.attribute()
            .Select(x => x.IDENTIFIER().Symbol.Text)
            .ToList();
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

        if (context.rule_invocation() is { } ruleInvocation)
            return VisitRule_invocation(ruleInvocation);

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

    public override Rule VisitRule_invocation(RMALRParser.Rule_invocationContext context)
    {
        var namedRule = _ruleNameToRule[context.IDENTIFIER().GetText()];
        
        var argumentList = context.argument_list() is { } argumentListContext
            ? VisitArgumentList(argumentListContext)
            : Array.Empty<string>();

        return new InvocationRule(namedRule, argumentList);
    }

    public IReadOnlyCollection<string> VisitArgumentList(RMALRParser.Argument_listContext context)
    {
        return context.argument()
            .Select(x => x.IDENTIFIER().GetText())
            .ToList();
    }
}