using Lab4.Lexis.Tokens;
using Lab4.Syntax.Rules.BaseClasses;

namespace Lab4.Syntax.Rules.Services;

public class FollowCalculator2
{
    private Dictionary<Rule, HashSet<string>> _result = new();
    private Dictionary<Rule, bool> _visited = new();

    public Dictionary<Rule, HashSet<string>> Calculate(NamedRule[] rules)
    {
        _result.Clear();
        
        _result.Add(rules.First(), new HashSet<string>(new [] {FinishToken.TokenType}));

        for (int i = 0; i < 100; i++)
        {
            foreach (var rule in rules)
            {
                AppendRule(rule);
            }
            _visited.Clear();
        }

        return _result;
    }

    private void AppendRule(Rule rule)
    {
        if (_visited.TryGetValue(rule, out bool visited) && visited)
            return;

        _visited.TryAdd(rule, true); 
        _visited[rule] = true;
        
        switch (rule)
        {
            case ActionRule actionRule:
                AppendActionRule(actionRule);
                break;
            case CompositeRule compositeRule:
                AppendCompositeRule(compositeRule);
                break;
            case EmptyRule emptyRule:
                AppendEmptyRule(emptyRule);
                break;
            case InvocationRule invocationRule:
                AppendInvocationRule(invocationRule);
                break;
            case NamedRule namedRule:
                AppendNamedRule(namedRule);
                break;
            case OptionsRule optionsRule:
                AppendOptionRule(optionsRule);
                break;
            case TokenRule tokenRule:
                AppendTokenRule(tokenRule);
                break;
        }
    }

    private void AppendActionRule(ActionRule actionRule)
    {
        _result.TryAdd(actionRule, new HashSet<string>());
        _result.TryAdd(actionRule.Payload, _result[actionRule]);
        AppendRule(actionRule.Payload);
        _result[actionRule.Payload].UnionWith(_result[actionRule]);
    }

    private void AppendCompositeRule(CompositeRule compositeRule)
    {
        _result.TryAdd(compositeRule, new HashSet<string>());

        var rules = compositeRule.Rules.ToArray();
        for (int i = 0; i < rules.Length - 1; i++)
        {
            var following = new CompositeRule(rules[(i + 1)..]);
            AppendRule(rules[i]);

            var followingFirst = following.First();

            if (followingFirst.Remove(EmptyToken.TokenType))
            {
                _result[rules[i]].UnionWith(_result[compositeRule]);
            }
            
            _result[rules[i]].UnionWith(followingFirst);
        }
        
        _result.TryAdd(rules.Last(), _result[compositeRule]);
        AppendRule(rules.Last());
        _result[rules.Last()].UnionWith(_result[compositeRule]);
    }

    private void AppendEmptyRule(EmptyRule emptyRule)
    {
        _result.TryAdd(emptyRule, new HashSet<string>());
    }

    private void AppendInvocationRule(InvocationRule invocationRule)
    {
        _result.TryAdd(invocationRule, new HashSet<string>());
        _result.TryAdd(invocationRule.NamedRule, _result[invocationRule]);
        AppendRule(invocationRule.NamedRule);
        _result[invocationRule.NamedRule].UnionWith(_result[invocationRule]);
    }

    private void AppendNamedRule(NamedRule namedRule)
    {
        _result.TryAdd(namedRule, new HashSet<string>());
        _result.TryAdd(namedRule.Payload, _result[namedRule]);
        AppendRule(namedRule.Payload);
        _result[namedRule.Payload].UnionWith(_result[namedRule]);
    }

    private void AppendOptionRule(OptionsRule optionsRule)
    {
        _result.TryAdd(optionsRule, new HashSet<string>());

        foreach (var rule in optionsRule.Options)
        {
            _result.TryAdd(rule, _result[optionsRule]);
            AppendRule(rule);
            _result[rule].UnionWith(_result[optionsRule]);
        }
    }

    private void AppendTokenRule(TokenRule tokenRule)
    {
        _result.TryAdd(tokenRule, new HashSet<string>());
    }
}