using BeeTrees.simple;
using BeeTrees.simple.Behaviors;

namespace BeeTrees.Tests.simple;

public class AcceptanceTests
{
    [Test]
    public void BT_CanBeEvaluated()
    {
        var action = new TaskAction(() => BeeTrees.simple.BehaviorStatus.Success);
        var condition = new Condition(() => true);
        var sequence = new Sequence();
        sequence.AddChild(condition);
        sequence.AddChild(action);
        var bt = new BehaviorTree();
        bt.SetRoot(sequence);
        var result = bt.Evaluate();
        Assert.AreEqual(BeeTrees.simple.BehaviorStatus.Success, result);
        Assert.That(result, Is.EqualTo(BeeTrees.simple.BehaviorStatus.Success));
    }
}
