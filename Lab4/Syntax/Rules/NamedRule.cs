namespace Lab4.Syntax.Rules;

public class NamedRule : RuleBase
{
    public NamedRule(string name, OptionsRule? options = default)
    {
        Name = name;
        Options = options;
    }

    public string Name { get; }
    
    public OptionsRule? Options { get; set; }

    public override HashSet<string> First()
    {
        if (Options is null)
            throw new InvalidOperationException("Не установлены возможные опции правила");

        return Options.First();
    }
}