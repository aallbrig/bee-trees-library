using BeeTrees.bt;
using BeeTrees.bt.Behaviors;

namespace BeeTrees.Tests.bt.AcceptanceTests.Behaviors;

public class ParallelBehaviorTests
{
    [Test, TestCaseSource(typeof(ParallelBehaviorTests), nameof(ParallelBehaviorTestCases))]
    public void ParallelBehavior_TestCases(IEnumerable<IBehavior> testCaseChildren, BehaviorStatus expectedStatus, ParallelPolicy successPolicy = ParallelPolicy.All, ParallelPolicy failPolicy = ParallelPolicy.One)
    {
        var sut = new ParallelBehavior(testCaseChildren, successPolicy, failPolicy);

        var status = sut.Evaluate();

        Assert.AreEqual(expectedStatus, status);
    }
    public static IEnumerable<TestCaseData> ParallelBehaviorTestCases()
    {
        // success = One, fail = One
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Running), new ConditionBehavior(() => true)}, BehaviorStatus.Success, ParallelPolicy.One, ParallelPolicy.One);
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Running), new ConditionBehavior(() => false)}, BehaviorStatus.Fail, ParallelPolicy.One, ParallelPolicy.One);
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Running), new ActionBehavior(() => BehaviorStatus.Running)}, BehaviorStatus.Running, ParallelPolicy.One, ParallelPolicy.One);
        // success = One, fail = All
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ConditionBehavior(() => false)}, BehaviorStatus.Success, ParallelPolicy.One, ParallelPolicy.All);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => false), new ConditionBehavior(() => false)}, BehaviorStatus.Fail, ParallelPolicy.One, ParallelPolicy.All);
        // success = All, fail = One
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ConditionBehavior(() => true)}, BehaviorStatus.Success, ParallelPolicy.All, ParallelPolicy.One);
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Running), new ConditionBehavior(() => true)}, BehaviorStatus.Running, ParallelPolicy.All, ParallelPolicy.One);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ConditionBehavior(() => false)}, BehaviorStatus.Fail, ParallelPolicy.All, ParallelPolicy.One);
        // success = All, fail = All
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ConditionBehavior(() => true)}, BehaviorStatus.Success, ParallelPolicy.All, ParallelPolicy.All);
        yield return new TestCaseData(new List<IBehavior> {new ActionBehavior(() => BehaviorStatus.Running), new ConditionBehavior(() => true)}, BehaviorStatus.Running, ParallelPolicy.All, ParallelPolicy.All);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => true), new ConditionBehavior(() => false)}, BehaviorStatus.Running, ParallelPolicy.All, ParallelPolicy.All);
        yield return new TestCaseData(new List<IBehavior> {new ConditionBehavior(() => false), new ConditionBehavior(() => false)}, BehaviorStatus.Fail, ParallelPolicy.All, ParallelPolicy.All);
    }
}
