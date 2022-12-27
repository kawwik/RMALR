namespace Lab4.Syntax.Nodes;

public class NonTerminalNode : Node
{
    private readonly List<Node> _children = new();
    
    public NonTerminalNode(string type)
    {
        Type = type;
    }

    public string Type { get; }

    public void AddChild(Node node) => _children.Add(node);
}