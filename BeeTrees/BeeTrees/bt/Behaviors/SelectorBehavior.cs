using System.Collections;

namespace BeeTrees.bt.Behaviors;

public class SelectorBehavior: IBehavior
{
    private readonly IEnumerable<IBehavior> _children;
    private readonly IEnumerator<IBehavior> _enumerator;
    public SelectorBehavior(IEnumerable<IBehavior> children)
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
                case BehaviorStatus.Fail:
                    continue;
                default:
                    return CurrentStatus;
            }
        CurrentStatus = BehaviorStatus.Fail;
        return CurrentStatus;
    }

    public BehaviorStatus CurrentStatus { get; private set; } = BehaviorStatus.Clean;
}
