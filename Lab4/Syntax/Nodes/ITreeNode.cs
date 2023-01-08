namespace Lab4.Syntax.Nodes;

public interface ITreeNode
{
    public string Name { get; }

    public IReadOnlyCollection<ITreeNode> Children { get; }
    
    public IReadOnlyCollection<ITreeNode> NotEmptyChildren { get; }

    public bool Empty { get; }
}