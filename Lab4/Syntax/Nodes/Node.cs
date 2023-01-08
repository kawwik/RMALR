namespace Lab4.Syntax.Nodes;

public abstract class Node : ITreeNode
{
    public abstract string Type { get; }
    public abstract dynamic this[string attribute] { get; set; }

    public virtual string Name => Type;
    
    public abstract IReadOnlyCollection<ITreeNode> Children { get; }

    public IReadOnlyCollection<ITreeNode> NotEmptyChildren => Children.Where(x => !x.Empty).ToList();

    public virtual bool Empty => !Children.Any();
}