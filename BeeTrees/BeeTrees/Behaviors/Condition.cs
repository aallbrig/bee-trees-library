namespace BeeTrees.Behaviors;

public class Condition: Leaf
{
    readonly Func<bool> _condition;
    public Condition(Func<bool> condition)
    {
        _condition = condition;
    }
    public override void Tick()
    {
        Status = _condition.Invoke() ? BehaviorStatus.Success : BehaviorStatus.Failure;
    }
}
