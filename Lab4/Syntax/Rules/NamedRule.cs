namespace Lab4.Syntax.Rules;

public class NamedRule : Rule
{
    private Rule? _optionsRule;

    public NamedRule(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public Rule Rule
    {
        get => _optionsRule ?? throw new InvalidOperationException("Правило не установлено");
        set => _optionsRule = value;
    }

    protected override HashSet<string> FirstInternal() => Rule.First();
}