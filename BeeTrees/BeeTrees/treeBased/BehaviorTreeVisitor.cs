using BeeTrees.treeBased;

namespace BeeTrees;

public class BehaviorTreeTraverser
{
    private TreeNode _currentTreeNode;
    private readonly BehaviorTree _bt;
    public BehaviorTreeTraverser(BehaviorTree behaviorTree)
    {
        _bt = behaviorTree;
    }
    public void Traverse()
    {
        
    }
}
