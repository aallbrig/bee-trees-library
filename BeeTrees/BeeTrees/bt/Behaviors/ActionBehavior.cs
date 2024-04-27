namespace BeeTrees.bt.Behaviors;

public class ActionBehavior: IBehavior
{
    public BehaviorStatus CurrentStatus { get; private set; } = BehaviorStatus.Clean;
    private readonly Func<BehaviorStatus> _inputFunction;
    public ActionBehavior(Func<BehaviorStatus> inputFunction)
    {
        _inputFunction = inputFunction;
    }
    public BehaviorStatus Evaluate()
    {
        CurrentStatus = _inputFunction.Invoke();
        return CurrentStatus;
    }
}
