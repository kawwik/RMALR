namespace Lab4.Syntax.Rules;

public class OptionsRule : RuleBase
{
    public OptionsRule(IReadOnlyCollection<RuleBase> options)
    {
        Options = options;
    }

    public IReadOnlyCollection<RuleBase> Options { get; }
}