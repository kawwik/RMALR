namespace Lab4.Syntax.Rules;

public class CompositeRule : RuleBase
{
    private readonly List<RuleBase> _rules;

    public CompositeRule(IReadOnlyCollection<RuleBase> rules)
    {
        _rules = rules.ToList();
    }

    public IReadOnlyCollection<RuleBase> Rules => _rules;

    public void AddRule(RuleBase rule) => _rules.Add(rule);
}