namespace Lab4.Syntax.Rules;

public class NamedRule : RuleBase
{
    public NamedRule(string name)
    {
        Name = name;
    }

    public string Name { get; }
    
    public CompositeRule[]? Options { get; set; }

    public override HashSet<string> First()
    {
        if (Options is null)
            throw new InvalidOperationException("Не установлены Option");

        // TODO: учесть пустые   
        return Options.First().First();
    }
}