namespace Lab4.Syntax.Rules;

public class NamedRule : Rule
{
    private CompositeRule[]? _options;

    public NamedRule(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public CompositeRule[] Options
    {
        get => _options ?? throw new InvalidOperationException("Опции не установлены");
        set => _options = value;
    }

    protected override HashSet<string> FirstInternal()
    {
        return Options.Aggregate(new HashSet<string>(), (set, rule) =>
        {
            set.UnionWith(rule.First());
            return set;
        });
    }
}