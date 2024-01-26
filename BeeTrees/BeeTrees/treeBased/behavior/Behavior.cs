using System.Security.Cryptography;

namespace BeeTrees;

public abstract class Behavior
{
    protected Behavior()
    {
        Name = GetType().Name;
        Status = BehaviorStatus.Clean;
    }
    public string Name { get; }
    public BehaviorStatus Status { get; protected set; }
    public abstract void Tick();
}
