namespace Lab4.Syntax.Rules;

public class Rule : RuleBase
{
    public Rule(string name, IReadOnlyCollection<RuleBase> rules)
    {
        Name = name;
        Rules = rules;
    }

    public string Name { get; }
    
    public IReadOnlyCollection<RuleBase> Rules { get; }
}