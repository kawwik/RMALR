namespace Lab4.Syntax.Rules;

public class NamedRule : RuleBase
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

    public override HashSet<string> First()
    {
        // TODO: учесть пустые   
        return Options.First().First();
    }
}