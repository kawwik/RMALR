using Lab4.Syntax.Nodes;

namespace Lab4.Visualization.Interfaces;

public interface ICodeGenerator
{
    string GenerateFromTree(ITreeNode treeNode);
}