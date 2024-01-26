namespace BeeTrees.simple;

public class BehaviorTree
{
    private IBehavior Root { get; set; }
    public void SetRoot(Behavior root)
    {
        Root = root;
    }
    public BehaviorStatus Evaluate()
    {
        return Root.Tick();
    }
}
