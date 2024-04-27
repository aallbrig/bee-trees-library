namespace BeeTrees.bt.Behaviors;

public enum ParallelPolicy
{
    One, All
}
public class ParallelBehavior: IBehavior
{
    private readonly IEnumerable<IBehavior> _children;
    private readonly IEnumerator<IBehavior> _enumerator;
    private readonly ParallelPolicy _successPolicy;
    private readonly ParallelPolicy _failPolicy;
    public ParallelBehavior(IEnumerable<IBehavior> children, ParallelPolicy successPolicy = ParallelPolicy.One, ParallelPolicy failPolicy = ParallelPolicy.One)
    {
        _children = children;
        _enumerator = _children.GetEnumerator();
        _successPolicy = successPolicy;
        _failPolicy = failPolicy;
    }
    public BehaviorStatus Evaluate()
    {
        _enumerator.Reset();
        var successCount = 0;
        var failCount = 0;
        CurrentStatus = BehaviorStatus.Running;
        while (_enumerator.MoveNext())
            switch (_enumerator.Current.Evaluate())
            {
                case BehaviorStatus.Success:
                    successCount++;
                    break;
                case BehaviorStatus.Fail:
                    failCount++;
                    break;
            }
        if (_successPolicy == ParallelPolicy.One && successCount >= 1)
        {
            CurrentStatus = BehaviorStatus.Success;
            return CurrentStatus;
        }
        if (_successPolicy == ParallelPolicy.All && successCount == _children.Count())
        {
            CurrentStatus = BehaviorStatus.Success;
            return CurrentStatus;
        }
        if (_failPolicy == ParallelPolicy.One && failCount >= 1)
        {
            CurrentStatus = BehaviorStatus.Fail;
            return CurrentStatus;
        }
        if (_failPolicy == ParallelPolicy.All && failCount == _children.Count())
        {
            CurrentStatus = BehaviorStatus.Fail;
            return CurrentStatus;
        }
        return CurrentStatus;
    }

    public BehaviorStatus CurrentStatus { get; private set; } = BehaviorStatus.Clean;
}
