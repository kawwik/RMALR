using Lab4.Lexis.Tokens;
using Lab4.Syntax.Rules.BaseClasses;

namespace Lab4.Syntax.Rules.Services;

public class FollowCalculator
{
    private readonly Dictionary<Rule, HashSet<string>> _result = new();
    private readonly Dictionary<Rule, bool> _visited = new();

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
        return _result.TryAdd(actionRule, new HashSet<string>())
               | AppendRule(actionRule.Payload)
               | _result[actionRule.Payload].UnionWith<string>(_result[actionRule]);
    }

    private bool AppendCompositeRule(CompositeRule compositeRule)
    {
        var changed = _result.TryAdd(compositeRule, new HashSet<string>());

        var rules = compositeRule.Rules.ToArray();
        for (int i = 0; i < rules.Length - 1; i++)
        {
            var following = new CompositeRule(rules[(i + 1)..]);
            changed |= AppendRule(rules[i]);

            var followingFirst = following.First();

            if (followingFirst.Remove(EmptyToken.TokenType))
            {
                changed |= _result[rules[i]].UnionWith<string>(_result[compositeRule]);
            }

            changed |= _result[rules[i]].UnionWith<string>(followingFirst);
        }

        changed |= AppendRule(rules.Last());
        return changed | _result[rules.Last()].UnionWith<string>(_result[compositeRule]);
    }

    private bool AppendEmptyRule(EmptyRule emptyRule)
    {
        return _result.TryAdd(emptyRule, new HashSet<string>());
    }

    private bool AppendInvocationRule(InvocationRule invocationRule)
    {
        return _result.TryAdd(invocationRule, new HashSet<string>())
               | AppendRule(invocationRule.NamedRule)
               | _result[invocationRule.NamedRule].UnionWith<string>(_result[invocationRule]);
    }

    private bool AppendNamedRule(NamedRule namedRule)
    {
        return _result.TryAdd(namedRule, new HashSet<string>())
               | AppendRule(namedRule.Payload)
               | _result[namedRule.Payload].UnionWith<string>(_result[namedRule]);
    }

    private bool AppendOptionRule(OptionsRule optionsRule)
    {
        var changed = _result.TryAdd(optionsRule, new HashSet<string>());

        foreach (var rule in optionsRule.Options)
        {
            changed |= AppendRule(rule);
            changed |= _result[rule].UnionWith<string>(_result[optionsRule]);
        }

        return changed;
    }

    private bool AppendTokenRule(TokenRule tokenRule)
    {
        return _result.TryAdd(tokenRule, new HashSet<string>());
    }
}