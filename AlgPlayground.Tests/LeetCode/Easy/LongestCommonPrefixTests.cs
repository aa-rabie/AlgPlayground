using AlgPlayGroundApp.LeetCode.Easy;
using NUnit.Framework;

namespace AlgPlayground.Tests.LeetCode.Easy
{
    public class LongestCommonPrefixTests
    {
        [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
        [TestCase(new string[] { "dog", "racecar", "car" }, "")]
        public void Test(string[] input, string expected)
        {
            var sut = new LongestCommonPrefix();
            var actual = sut.Solution(input);
            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}