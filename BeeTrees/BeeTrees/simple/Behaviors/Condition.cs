namespace BeeTrees.simple.Behaviors;

public class Condition: Leaf
{
    private readonly Func<bool> _conditional;
    public Condition(Func<bool> conditional)
    {
        _conditional = conditional;
    }

    public override BehaviorStatus Tick()
    {
        if (_conditional.Invoke()) return BehaviorStatus.Success;
        return BehaviorStatus.Failure;
    }
}
