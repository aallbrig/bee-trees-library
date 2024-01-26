using System.Diagnostics;

namespace BeeTrees.simple.Behaviors;

public abstract class Decorator: Composite
{
    protected IBehavior Child => children[0];
    
    public override void AddChild(IBehavior child)
    {
        if (children.Count == 0)
            children.Add(child);
        else
        {
            Console.WriteLine("Replacing child in Decorator");
            children[0] = child;
        }
            
    }
}
