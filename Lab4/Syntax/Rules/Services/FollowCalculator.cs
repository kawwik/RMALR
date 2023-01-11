using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Lab4.Lexis.Tokens;
using Lab4.Syntax.Rules.BaseClasses;

namespace Lab4.Syntax.Rules.Services;

public class FollowCalculator
{
    private Dictionary<Rule, HashSet<string>> _result = new();
    private Dictionary<Rule, bool> _visited = new();

    public Dictionary<Rule, HashSet<string>> Calculate(NamedRule[] rules)
    {
        _result.Clear();
        _result.Add(rules.First(), new HashSet<string>(new[] { FinishToken.TokenType }));

        var changed = false;
        do
        {
            changed = false;
            foreach (var rule in rules)
                changed |= AppendRule(rule);

            _visited.Clear();
        } while (changed);
        
        return _result;
    }

    private bool AppendRule(Rule rule)
    {
        if (_visited.TryGetValue(rule, out bool visited) && visited)
            return false;

        _visited.TryAdd(rule, true);
        _visited[rule] = true;

        return rule switch
        {
            ActionRule actionRule => AppendActionRule(actionRule),
            CompositeRule compositeRule => AppendCompositeRule(compositeRule),
            EmptyRule emptyRule => AppendEmptyRule(emptyRule),
            InvocationRule invocationRule => AppendInvocationRule(invocationRule),
            NamedRule namedRule => AppendNamedRule(namedRule),
            OptionsRule optionsRule => AppendOptionRule(optionsRule),
            TokenRule tokenRule => AppendTokenRule(tokenRule),
            _ => throw new NotSupportedException($"Правило {rule.GetType().Name} не поддерживается")
        };
    }

    private bool AppendActionRule(ActionRule actionRule)
    {
        var result = _result.TryAdd(actionRule, new HashSet<string>());
        result |= AppendRule(actionRule.Payload);
        return result | _result[actionRule.Payload].UnionWith<string>(_result[actionRule]);
    }

    private bool AppendCompositeRule(CompositeRule compositeRule)
    {
        var result = _result.TryAdd(compositeRule, new HashSet<string>());

        var rules = compositeRule.Rules.ToArray();
        for (int i = 0; i < rules.Length - 1; i++)
        {
            var following = new CompositeRule(rules[(i + 1)..]);
            result |= AppendRule(rules[i]);

            var followingFirst = following.First();

            if (followingFirst.Remove(EmptyToken.TokenType))
            {
                _result[rules[i]].UnionWith(_result[compositeRule]);
            }

            result |= _result[rules[i]].UnionWith<string>(followingFirst);
        }

        result |= AppendRule(rules.Last());
        return result | _result[rules.Last()].UnionWith<string>(_result[compositeRule]);
    }

    private bool AppendEmptyRule(EmptyRule emptyRule)
    {
        return _result.TryAdd(emptyRule, new HashSet<string>());
    }

    private bool AppendInvocationRule(InvocationRule invocationRule)
    {
        var result = _result.TryAdd(invocationRule, new HashSet<string>());
        result |= AppendRule(invocationRule.NamedRule);

        return result | _result[invocationRule.NamedRule].UnionWith<string>(_result[invocationRule]);
    }

    private bool AppendNamedRule(NamedRule namedRule)
    {
        var result =_result.TryAdd(namedRule, new HashSet<string>());
        result |= AppendRule(namedRule.Payload);

        return result | _result[namedRule.Payload].UnionWith<string>(_result[namedRule]);
    }

    private bool AppendOptionRule(OptionsRule optionsRule)
    {
        var result = _result.TryAdd(optionsRule, new HashSet<string>());

        foreach (var rule in optionsRule.Options)
        {
            result |= AppendRule(rule);
            result |= _result[rule].UnionWith<string>(_result[optionsRule]);
        }

        return result;
    }

    private bool AppendTokenRule(TokenRule tokenRule)
    {
        return _result.TryAdd(tokenRule, new HashSet<string>());
    }
}