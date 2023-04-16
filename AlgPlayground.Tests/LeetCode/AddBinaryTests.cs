using AlgPlayGroundApp.LeetCode;
using AlgPlayGroundApp.LeetCode.Easy;
using NUnit.Framework;

namespace AlgPlayground.Tests.LeetCode
{
    public class AddBinaryTests
    {
        [TestCase("1","11","100")]
        [TestCase("11", "1", "100")]
        [TestCase("1010", "1011", "10101")]
        [TestCase("1011", "1010", "10101")]
        public void Test(string a, string b, string expected)
        {
            var sut = new AddBinaryProblem();
            var actual = sut.AddBinary(a, b);
            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}