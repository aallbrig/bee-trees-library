namespace BeeTrees.bt.Behaviors;

public class ConditionBehavior: IBehavior
{
    private readonly Func<bool> _inputPredicate;
    public ConditionBehavior(Func<bool> inputPredicate)
    {
        _inputPredicate = inputPredicate;
    }

    public BehaviorStatus Evaluate()
    {
        CurrentStatus = _inputPredicate.Invoke() ? BehaviorStatus.Success : BehaviorStatus.Fail;
        return CurrentStatus;
    }

    public BehaviorStatus CurrentStatus { get; private set; } = BehaviorStatus.Clean;
}
