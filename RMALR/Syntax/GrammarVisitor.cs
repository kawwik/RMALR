﻿using Lab4.Generated;
using RMALR.Syntax.Rules;
using RMALR.Syntax.Rules.BaseClasses;

namespace RMALR.Syntax;

public class GrammarVisitor : RMALR_parserBaseVisitor<Rule>
{
    private readonly Dictionary<string, NamedRule> _ruleNameToRule = new();

    public List<NamedRule> GetAllRules(RMALR_parser.StartContext context)
    {
        _ruleNameToRule.Clear();

        DefineRules(context);

        return context.rule_definition()
            .Select(VisitRule_definition)
            .ToList();
    }

    private void DefineRules(RMALR_parser.StartContext context)
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

    public override NamedRule VisitRule_definition(RMALR_parser.Rule_definitionContext context)
    {
        var namedRule = _ruleNameToRule[context.IDENTIFIER().GetText()];
        var ruleBody = VisitRule_body(context.rule_body());
        namedRule.Payload = ruleBody;

        return namedRule;
    }


    private List<string> VisitAttributeList(RMALR_parser.Attribute_listContext context)
    {
        return context.attribute()
            .Select(x => x.IDENTIFIER().Symbol.Text)
            .ToList();
    }

    public override Rule VisitRule_body(RMALR_parser.Rule_bodyContext context)
    {
        var options = context.rule_option()
            .Select(VisitRule_option)
            .ToArray();

        return options.Length == 1
            ? options.First()
            : new OptionsRule(options);
    }

    public override Rule VisitRule_option(RMALR_parser.Rule_optionContext context)
    {
        var ruleParts = context.rule_part()
            .Select(VisitRule_part)
            .ToArray();

        var rule = ruleParts.Length switch
        {
            0 => new EmptyRule(),
            1 => ruleParts.Single(),
            _ => new CompositeRule(ruleParts)
        };
        
        return context.action() is { } action 
            ? new ActionRule(rule, action.CODE().GetText())
            : rule;
    }

    public override Rule VisitRule_part(RMALR_parser.Rule_partContext context)
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

    public override Rule VisitRule_invocation(RMALR_parser.Rule_invocationContext context)
    {
        var namedRule = _ruleNameToRule[context.IDENTIFIER().GetText()];
        
        var argumentList = context.argument_list() is { } argumentListContext
            ? VisitArgumentList(argumentListContext)
            : Array.Empty<string>();

        return new InvocationRule(namedRule, argumentList);
    }

    public IReadOnlyCollection<string> VisitArgumentList(RMALR_parser.Argument_listContext context)
    {
        return context.argument()
            .Select(x => x.GetText())
            .ToList();
    }
}