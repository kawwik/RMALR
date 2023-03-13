using System.Text;
using RMALR.Syntax.Nodes;
using RMALR.Visualization.Interfaces;

namespace RMALR.Visualization;

public class GraphVizCodeGenerator : ICodeGenerator
{
    public GraphVizCodeGenerator(bool squash, bool hideEmptyChildren)
    {
        Squash = squash;
        HideEmptyChildren = hideEmptyChildren;
    }

    public bool Squash { get; }
    
    public bool HideEmptyChildren { get; }

    public string GenerateFromTree(ITreeNode root)
    {
        var result = new StringBuilder();
        var queue = new Queue<(ITreeNode, Guid)>();

        result.Append("strict graph G {\n");

        queue.Enqueue((root, Guid.NewGuid()));

        while (queue.Count > 0)
        {
            var (currentNode, id) = queue.Dequeue();

            if (Squash)
            {
                while (GetChildren(currentNode).Count == 1)
                {
                    currentNode = GetChildren(currentNode).Single();
                }
            }

            result.Append($"\"{id}\" [label=\"{currentNode.Name}\"];\n");

            foreach (var child in GetChildren(currentNode))
            {
                var childId = Guid.NewGuid();
                var str = $"\"{id}\" -- \"{childId}\";\n";
                result.Append(str);
                queue.Enqueue((child, childId));
            }
        }

        result.Append("}");
        return result.ToString();
    }

    private IReadOnlyCollection<ITreeNode> GetChildren(ITreeNode node) =>
         HideEmptyChildren ? node.NotEmptyChildren : node.Children;
}