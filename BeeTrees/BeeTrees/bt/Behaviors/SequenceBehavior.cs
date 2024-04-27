using System.Collections;

namespace BeeTrees.bt.Behaviors;

public class SequenceBehavior: IBehavior
{
    private readonly IEnumerable<IBehavior> _children;
    private readonly IEnumerator<IBehavior> _enumerator;
    private IBehavior _currentChild;
    public SequenceBehavior(IEnumerable<IBehavior> children)
    {
        _children = children;
        _enumerator = _children.GetEnumerator();
    }
    public BehaviorStatus Evaluate()
    {
        CurrentStatus = BehaviorStatus.Running;
        while (_enumerator.MoveNext())
            switch (_enumerator.Current.Evaluate())
            {
                case BehaviorStatus.Clean:
                    CurrentStatus = BehaviorStatus.Fail;
                    return CurrentStatus;
                case BehaviorStatus.Success:
                    continue;
                default:
                    CurrentStatus = BehaviorStatus.Running;
                    return CurrentStatus;
            }
        CurrentStatus = BehaviorStatus.Success;
        return CurrentStatus;
    }

    public BehaviorStatus CurrentStatus { get; private set; } = BehaviorStatus.Clean;
}
