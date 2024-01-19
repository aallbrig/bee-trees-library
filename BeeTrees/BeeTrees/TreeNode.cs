using System.Text;
using BeeTrees.Behaviors;

namespace BeeTrees;

public class TreeNode
{
    public TreeNode? Parent { get; private set; }
    public List<TreeNode> Children { get; } = new();
    public Behavior Behavior { get; private set; }

    public void AddBehavior(Behavior behavior)
    {
        Behavior = behavior;
    }

    public void AddChild(TreeNode child)
    {
        if (Behavior is Leaf) throw new ArgumentException("Leaf nodes cannot have children.");

        child.Parent = this;
        Children.Add(child);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Behavior.Name} ({Behavior.Status})");
        foreach (var child in Children)
        {
            sb.AppendLine($"|-- {child.Behavior.Name} ({child.Behavior.Status})");
        }

        return sb.ToString();
    }
}
