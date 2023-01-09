using Lab4.Lexis.Tokens;
using Lab4.Syntax.Rules.BaseClasses;

namespace Lab4.Syntax.Rules.Services;

public class FollowCalculator
{
    private Dictionary<Rule, HashSet<string>> _result = new();

    public Dictionary<Rule, HashSet<string>> Calculate(NamedRule[] rules)
    {
        _result.Clear();
        foreach (var rule in rules)
        {
            AppendNamedRule(rule);
        }

        return _result;
    }


    private void AppendRule(Rule rule)
    {
        switch (rule)
        {
            case OptionsRule optionsRule:
                AppendOptionsRule(optionsRule);
                break;
            case NamedRule namedRule:
                AppendNamedRule(namedRule);
                break;
            case InvocationRule invocationRule:
                AppendInvocationRule(invocationRule);
                break;
            case ActionRule actionRule:
                AppendActionRule(actionRule);
                break;
            case CompositeRule compositeRule:
                AppendCompositeRule(compositeRule);
                break;
        }
    }

    private void AppendCompositeRule(CompositeRule compositeRule)
    {
        _result.TryAdd(compositeRule, new HashSet<string>());
        const string epsilon = EmptyToken.TokenType;

        var rules = compositeRule.Rules.ToArray();
        for (int i = 0; i < rules.Length - 1; i++)
        {
            var rule = rules[i];
            var firstOfNext = rules[i + 1].First();

            if (rule is EmptyRule or TokenRule)
                continue;
            
            AppendRule(rule);

            firstOfNext.Remove(epsilon);
            _result[rule].UnionWith(firstOfNext);
        }
        
        AppendRule(rules.Last());
        
        var lastNotEmpty = rules.Length - 1;
        for (; lastNotEmpty > 0 && rules[lastNotEmpty].First().Contains(epsilon); lastNotEmpty--) 
            ;
        
        if (lastNotEmpty == -1)
            return;
        
        _result[rules[lastNotEmpty]].UnionWith(_result[compositeRule]!);
    }

    private void AppendActionRule(ActionRule actionRule)
    {
        _result.TryAdd(actionRule, new HashSet<string>());
        AppendRule(actionRule.Payload);
        _result[actionRule].UnionWith(_result[actionRule.Payload]!);
    }

    private void AppendInvocationRule(InvocationRule invocationRule)
    {
        _result.TryAdd(invocationRule, new HashSet<string>());
    }

    private void AppendNamedRule(NamedRule namedRule)
    {
        _result.TryAdd(namedRule, new HashSet<string>());
        AppendRule(namedRule.Payload);
        _result[namedRule].UnionWith(_result[namedRule.Payload]!);
    }

    private void AppendOptionsRule(OptionsRule optionsRule)
    {
        _result.TryAdd(optionsRule, new HashSet<string>());
        foreach (var rule in optionsRule.Options)
        {
            AppendRule(rule);
            
            if (rule is EmptyRule or TokenRule)
                continue;
            
            _result[optionsRule].UnionWith(_result[rule]!);
        }
    }
}