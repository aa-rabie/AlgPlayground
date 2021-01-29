using AlgPlayGroundApp.LeetCode.Easy;
using NUnit.Framework;

namespace AlgPlayground.Tests.LeetCode.Easy
{
    public class MinStackTests
    {
        [Test]
        public void FirstTest()
        {
            var minStack = new MySolution.MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            var actual = minStack.GetMin(); // return -3
            Assert.AreEqual(actual, -3);
            minStack.Pop();
            actual = minStack.Top();    // return 0
            Assert.AreEqual(actual, 0);
            actual = minStack.GetMin(); // return -2
            Assert.AreEqual(actual, -2);
        }
    }
}