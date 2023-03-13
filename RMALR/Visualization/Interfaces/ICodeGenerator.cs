using RMALR.Syntax.Nodes;

namespace RMALR.Visualization.Interfaces;

public interface ICodeGenerator
{
    string GenerateFromTree(ITreeNode treeNode);
}