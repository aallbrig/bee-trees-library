namespace BeeTrees.simple.Behaviors;

public class Sequence: Composite
{
    public override BehaviorStatus Tick()
    {
        foreach (var behavior in children)
        {
            var status = behavior.Tick();
            if (status != BehaviorStatus.Success)
            {
                return status;
            }
        }
        return BehaviorStatus.Success;
    }
}
