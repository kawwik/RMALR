using Lab4.Syntax.Rules.BaseClasses;

namespace Lab4.Syntax.Rules;

public class InvocationRule : UnnamedRule
{
    public InvocationRule(NamedRule namedRule, IReadOnlyCollection<string> arguments)
    {
        NamedRule = namedRule;
        Arguments = arguments;

        if (NamedRule.InheritedAttributes.Count != arguments.Count)
            throw new ArgumentException("Количество аргументов должно совпадать с арностью правила", nameof(arguments));
    }

    public NamedRule NamedRule { get; }
    
    public IReadOnlyCollection<string> Arguments { get; }

    protected override HashSet<string> FirstInternal() => NamedRule.First();
}