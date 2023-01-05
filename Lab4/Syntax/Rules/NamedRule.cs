namespace Lab4.Syntax.Rules;

public class NamedRule : Rule
{
    private Rule? _payload;

    public NamedRule(
        IReadOnlyCollection<string> inheritedAttributes,
        IReadOnlyCollection<string> synthesizedAttribute, 
        string name)
    {
        Name = name;
        InheritedAttributes = inheritedAttributes;
        SynthesizedAttribute = synthesizedAttribute;
    }

    public string Name { get; }

    public Rule Payload
    {
        get => _payload ?? throw new InvalidOperationException("Не установлено правило");
        set => _payload = value;
    }

    public IReadOnlyCollection<string> InheritedAttributes { get; }
    
    public IReadOnlyCollection<string> SynthesizedAttribute { get; }

    protected override HashSet<string> FirstInternal() => Payload.First();
}