namespace Lab4.Syntax.Rules;

public class CompositeRule : RuleBase
{
    public CompositeRule(IReadOnlyCollection<RuleBase> rules)
    {
        Rules = rules;
    }

    public IReadOnlyCollection<RuleBase> Rules { get; }

    public override HashSet<string> First()
    {
        // TODO: учесть пустые
        return Rules.First().First();
    }
}