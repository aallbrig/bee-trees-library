namespace BeeTrees.simple.Behaviors;

public class Selector: Composite
{
    public override BehaviorStatus Tick()
    {
        foreach (var behavior in children)
        {
            var status = behavior.Tick();
            if (status != BehaviorStatus.Failure)
            {
                return status;
            }
        }
        return BehaviorStatus.Failure;
    }
}
