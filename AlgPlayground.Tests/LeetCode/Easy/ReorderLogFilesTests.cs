using AlgPlayGroundApp.LeetCode.Easy;
using NUnit.Framework;

namespace AlgPlayground.Tests.LeetCode.Easy
{
    public class ReorderLogFilesTests
    {
        [TestCase(new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" },
            new string[] { "let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6" })]
        [TestCase(new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo" },
            new string[] { "g1 act car", "a8 act zoo", "ab1 off key dog", "a1 9 2 3 1", "zo4 4 7" })]
        [TestCase(new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo", "a2 act car" },
            new string[] { "a2 act car", "g1 act car", "a8 act zoo", "ab1 off key dog", "a1 9 2 3 1", "zo4 4 7" })]
        [TestCase(new string[] { "j mo", "5 m w", "g 07", "o 2 0", "t q h" },
            new string[] { "5 m w", "j mo", "t q h", "g 07", "o 2 0" })]
        [TestCase(new string[] { "p2 kffypb", "i bq p sn", "5 qnyy ypm", "hj ar u zk", "qm uiliabj", "s rt wg s", "7 sbvz dc", "1 lcltvbem", "5 452 224", "tj u t h r" },
            new string[] { "hj ar u zk", "i bq p sn", "p2 kffypb", "1 lcltvbem", "5 qnyy ypm", "s rt wg s", "7 sbvz dc", "tj u t h r", "qm uiliabj", "5 452 224" })]
        public void FirstTestCase(string[] input, string[] expected)
        {
            var sut = new ReorderLogFilesProblem();
            var actual = sut.ReorderLogFiles(input);
            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [TestCase(new string[] { "p2 kffypb", "i bq p sn", "5 qnyy ypm", "hj ar u zk", "qm uiliabj", "s rt wg s", "7 sbvz dc", "1 lcltvbem", "5 452 224", "tj u t h r" },
            new string[] { "hj ar u zk", "i bq p sn", "p2 kffypb", "1 lcltvbem", "5 qnyy ypm", "s rt wg s", "7 sbvz dc", "tj u t h r", "qm uiliabj", "5 452 224" })]
        public void TrickyTestCase(string[] input, string[] expected)
        {
            var sut = new ReorderLogFilesProblem();
            var actual = sut.ReorderLogFiles(input);
            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}