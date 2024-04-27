using BeeTrees.bt;
using BeeTrees.bt.Behaviors;

namespace BeeTrees.Tests.bt.AcceptanceTests.Behaviors;

public class SelectorBehaviorTests
{
    [Test, TestCaseSource(typeof(SelectorBehaviorTests), nameof(SelectorBehaviorTestCases))]
    public void SelectorBehavior(List<IBehavior> testCaseChildren, BehaviorStatus expectedStatus)
    {
        var sut = new SelectorBehavior(testCaseChildren);

        var status = sut.Evaluate();

        Assert.AreEqual(expectedStatus, status);
    }
    public static IEnumerable<TestCaseData> SelectorBehaviorTestCases()
    {
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Running)}, BehaviorStatus.Running);
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Success)}, BehaviorStatus.Success);
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Fail), new ActionBehavior(() => BehaviorStatus.Success)}, BehaviorStatus.Success);
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Fail), new ActionBehavior(() => BehaviorStatus.Fail)}, BehaviorStatus.Fail);
    }
}
