namespace BeeTrees.Behaviors;

public class Task: Leaf
{
    readonly Func<BehaviorStatus> _task;
    public Task(Func<BehaviorStatus> task)
    {
        _task = task;
    }
    public override void Tick()
    {
        Status = _task.Invoke();
    }
}
