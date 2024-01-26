using System.Collections.ObjectModel;

namespace BeeTrees.simple.Behaviors;

public abstract class Composite: Behavior, IAddChildren
{
    private readonly Collection<IBehavior> _children = new Collection<IBehavior>();
    protected Collection<IBehavior> children => _children;
    public virtual void AddChild(IBehavior child)
    {
        children.Add(child);
    }
}
