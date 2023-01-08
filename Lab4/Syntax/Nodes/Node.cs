namespace Lab4.Syntax.Nodes;

public abstract class Node
{
    public abstract string Type { get; }
    public abstract dynamic this[string attribute] { get; set; }
}