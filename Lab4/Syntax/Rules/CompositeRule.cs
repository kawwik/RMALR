using Lab4.Lexis.Tokens;

namespace Lab4.Syntax.Rules;

public class CompositeRule : UnnamedRule
{
    public CompositeRule(IReadOnlyCollection<Rule> rules)
    {
        if (!rules.Any())
            throw new ArgumentException("Коллекция правил композитного правила не может быть пустой");
        
        Rules = rules;
    }

    public IReadOnlyCollection<Rule> Rules { get; }

    protected override HashSet<string> FirstInternal()
    {
        var rules = Rules.ToArray();
        var first = Rules.First().First();

        for (int i = 1; i < Rules.Count && first.Contains(EmptyToken.TokenType); i++)
        {
            first.Remove(EmptyToken.TokenType);
            first.UnionWith(rules[i].First());
        }

        return first;
    }
}