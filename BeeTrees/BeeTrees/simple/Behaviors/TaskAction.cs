namespace BeeTrees.simple.Behaviors;

public class TaskAction: Leaf
{
    readonly Func<BehaviorStatus> _task;
    public TaskAction(Func<BehaviorStatus> task)
    {
        _task = task;
    }
    public override BehaviorStatus Tick() => _task.Invoke();
}
