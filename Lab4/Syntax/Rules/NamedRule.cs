namespace Lab4.Syntax.Rules;

public class NamedRule : Rule
{
    private Rule? _payload;

    public NamedRule(string name, IReadOnlyCollection<string> inheritedAttributes)
    {
        Name = name;
        InheritedAttributes = inheritedAttributes;
    }

    public string Name { get; }

    public Rule Payload
    {
        get => _payload ?? throw new InvalidOperationException("Не установлено правило");
        set => _payload = value;
    }

    public IReadOnlyCollection<string> InheritedAttributes { get; }

    protected override HashSet<string> FirstInternal() => Payload.First();
}