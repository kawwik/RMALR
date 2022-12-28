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
        // TODO: учесть пустые   
        return Options.First().First();
    }
}