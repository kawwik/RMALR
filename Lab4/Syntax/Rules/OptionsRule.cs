namespace Lab4.Syntax.Rules;

public class OptionsRule : RuleBase
{
    public OptionsRule(IReadOnlyCollection<RuleBase> options)
    {
        Options = options;
    }

    public IReadOnlyCollection<RuleBase> Options { get; }

    // TODO: нужно учесть пустые множества
    public override HashSet<string> First()
    {
        return Options.Aggregate(new HashSet<string>(), (first, rule) =>
        {
            first.UnionWith(rule.First());
            return first;
        });
    }
}