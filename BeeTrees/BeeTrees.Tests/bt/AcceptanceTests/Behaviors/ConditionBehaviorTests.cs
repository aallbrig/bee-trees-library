using BeeTrees.bt;
using BeeTrees.bt.Behaviors;

namespace BeeTrees.Tests.bt.AcceptanceTests.Behaviors;

public class ConditionBehaviorTests
{
    [Test, TestCaseSource(typeof(ConditionBehaviorTests), nameof(ConditionBehaviorTestCases))]
    public void ConditionBehaviors_InputPredicateTrue_BehaviorSuccess(bool returnStatus, BehaviorStatus expectedStatus)
    {
        var sut = new ConditionBehavior(() => returnStatus);

        sut.Evaluate();

        Assert.AreEqual(expectedStatus, sut.CurrentStatus);
    }
    public static IEnumerable<TestCaseData> ConditionBehaviorTestCases()
    {
        yield return new TestCaseData(false, BehaviorStatus.Fail);
        yield return new TestCaseData(true, BehaviorStatus.Success);
    }
}
