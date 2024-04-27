using BeeTrees.bt;
using BeeTrees.bt.Behaviors;

namespace BeeTrees.Tests.bt.AcceptanceTests.Behaviors;

public class ActionBehaviorTests
{
    [Test, TestCaseSource(typeof(ActionBehaviorTests), nameof(ActionBehaviorTestCases))]
    public void ActionBehavior_TestCases(BehaviorStatus returnStatus, BehaviorStatus expectedStatus)
    {
        var inputFunctionCalled = false;
        var inputFunction = () =>
        {
            inputFunctionCalled = true;
            return returnStatus;
        };
        var sut = new ActionBehavior(inputFunction);

        var status = sut.Evaluate();

        Assert.IsTrue(inputFunctionCalled);
        Assert.AreEqual(expectedStatus, status);
    }
    public static IEnumerable<TestCaseData> ActionBehaviorTestCases()
    {
        yield return new TestCaseData(BehaviorStatus.Success, BehaviorStatus.Success);
        yield return new TestCaseData(BehaviorStatus.Running, BehaviorStatus.Running);
        yield return new TestCaseData(BehaviorStatus.Fail, BehaviorStatus.Fail);
    }
}
