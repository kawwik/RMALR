﻿namespace RMALR.Syntax.Nodes;

public class NonTerminalNode : Node
{
    private readonly List<Node> _children = new();

    public NonTerminalNode(string type)
    {
        Type = type;
    }

    public override string Type { get; }

    private Dictionary<string, dynamic> Attributes { get; } = new();

    public override dynamic this[string attribute]
    {
        get => Attributes[attribute];
        set => Attributes[attribute] = value;
    }

    public override IReadOnlyCollection<ITreeNode> Children => _children;

    public void AddChildren(params Node[] nodes) => _children.AddRange(nodes);

    public Node GetChild(string type, int number)
    {
        return _children.Where(x => x.Type == type).ToArray()[number - 1];
    } 
}