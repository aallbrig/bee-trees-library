namespace BeeTrees.bt;

public interface IBehavior
{
    public BehaviorStatus Evaluate();
    public BehaviorStatus CurrentStatus { get; }
}
