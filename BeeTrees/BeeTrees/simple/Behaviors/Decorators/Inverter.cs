namespace BeeTrees.simple.Behaviors.Decorators;

public class Inverter: Decorator
{

    public override BehaviorStatus Tick()
    {
        var status = Child.Tick();
        if (status == BehaviorStatus.Success)
            return BehaviorStatus.Failure;
        if (status == BehaviorStatus.Failure)
            return BehaviorStatus.Success;
        return status;
    }
}
