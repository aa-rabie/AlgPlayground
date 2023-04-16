using AlgPlayGroundApp.LeetCode.Arrays;
using AlgPlayGroundApp.LeetCode.Easy;
using NUnit.Framework;

namespace AlgPlayground.Tests.LeetCode
{
    public class TwoSumIITests
    {
        [TestCase(new int[] { -1, 0 }, -1, 
            new int[] {1 , 2})]
        public void TrickyTestCase(int[] nums,int target, int[] expected)
        {
            var actual = TwoSumII.Run(nums, target);
            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}