using System.Collections.Immutable;

namespace Lab4.Syntax.Nodes;

public class NonTerminalNode : Node
{
    private readonly List<Node> _children = new();

    private readonly Dictionary<string, dynamic> _attributes = new();

    public NonTerminalNode(string type)
    {
        Type = type;
    }

    public string Type { get; }

    public ImmutableDictionary<string, dynamic> Attributes => _attributes.ToImmutableDictionary();

    public void AddChildren(params Node[] nodes) => _children.AddRange(nodes);

    public void AddAttribute(string name, dynamic value) => _attributes.Add(name, value);
}