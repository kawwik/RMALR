namespace Lab4.Syntax.Rules;

public class OptionsRule : UnnamedRule
{
    public OptionsRule(params Rule[] options)
    {
        Options = options;
    }
    
    public Rule[] Options { get; }

    public override HashSet<string> First()
    {
        return Options.Aggregate(new HashSet<string>(), (set, rule) =>
        {
            set.UnionWith(rule.First());
            return set;
        });
    }
}