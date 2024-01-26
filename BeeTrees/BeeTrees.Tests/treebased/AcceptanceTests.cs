using BeeTrees.treeBased;

namespace BeeTrees.Tests;

public class AcceptanceTests
{
    [Test]
    public void BT_CanBeRepresentedInString()
    {
        var expectedStrRepresentation = @"BehaviorTree
|-- Task (Clean)
";
        var sut = new BehaviorTree();
        var foo = new TreeNode();
        foo.AddBehavior(new Behaviors.Task(() => BehaviorStatus.Clean));
        // sut.RootNode.AddChild(foo);
        var strRepresentation = sut.ToString();

        Assert.That(strRepresentation, Is.EqualTo(expectedStrRepresentation));
    }
}
