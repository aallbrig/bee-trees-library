using BeeTrees.bt;
using BeeTrees.bt.Behaviors;

namespace BeeTrees.Tests.bt.AcceptanceTests.Behaviors;

public class SequenceBehaviorTests
{
    [Test, TestCaseSource(typeof(SequenceBehaviorTests), nameof(GetSequenceTestCases))]
    public void SequenceBehavior_CanHandle(List<IBehavior> testCaseChildren, BehaviorStatus expectedStatus)
    {
        var sut = new SequenceBehavior(testCaseChildren);

        var status = sut.Evaluate();

        Assert.AreEqual(expectedStatus, status);
    }
    public static IEnumerable<TestCaseData> GetSequenceTestCases()
    {
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => false)}, BehaviorStatus.Fail);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ConditionBehavior(() => false)}, BehaviorStatus.Fail);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true)}, BehaviorStatus.Success);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ConditionBehavior(() => true)}, BehaviorStatus.Success);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ActionBehavior(() => BehaviorStatus.Running)}, BehaviorStatus.Running);
    }
}
