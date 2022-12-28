namespace Lab4.Syntax.Rules;

public class CompositeRule : UnnamedRule
{
    public CompositeRule(IReadOnlyCollection<Rule> rules)
    {
        Rules = rules;
    }

    public IReadOnlyCollection<Rule> Rules { get; }

    public override HashSet<string> First()
    {
        // TODO: учесть пустые
        return Rules.First().First();
    }
}