using System.Text;

namespace BeeTrees.treeBased;

public class BehaviorTree
{
    private TreeNode RootNode { get; } = new();

    public override string ToString()
    {
        if (RootNode.Children.Count == 0) return string.Empty;
        
        var sb = new StringBuilder();
        sb.AppendLine("BehaviorTree");
        foreach (var child in RootNode.Children)
        {
            sb.AppendLine($"|-- {child.Behavior.Name} ({child.Behavior.Status})");
        }
        return sb.ToString();
    }
}
