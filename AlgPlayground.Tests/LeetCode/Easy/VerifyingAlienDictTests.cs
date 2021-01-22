using AlgPlayGroundApp.LeetCode.Easy;
using NUnit.Framework;

namespace AlgPlayground.Tests.LeetCode.Easy
{
    public class VerifyingAlienDictTests
    {

        [Test]
        public void TestInputReturnTrue()
        {
            var order = "hlabcdefgijkmnopqrstuvwxyz";
            var words = new string[] {"hello", "leetcode"};
            var cls = new VerifyingAlienDict();
            var result = cls.IsAlienSorted(words, order);
            Assert.AreEqual(true,result);

            words = new string[] {"hello", "hello"};
            order = "abcdefghijklmnopqrstuvwxyz";
            result = cls.IsAlienSorted(words, order);
            Assert.AreEqual(true, result);
        }
       

        [Test]
        public void TestInputReturnFalse()
        {
            var order = "abcdefghijklmnopqrstuvwxyz";
            var words = new string[] { "apple", "app" };
            var cls = new VerifyingAlienDict();
            var result = cls.IsAlienSorted(words, order);
            Assert.AreEqual(false, result);

            order = "worldabcefghijkmnpqstuvxyz";
            words = new string[] { "word", "world", "row" };
            result = cls.IsAlienSorted(words, order);
            Assert.AreEqual(false, result);

            order = "loxbzapnmstkhijfcuqdewyvrg";
            words = new string[] { "iekm", "tpnhnbe" };
            result = cls.IsAlienSorted(words, order);
            Assert.AreEqual(false, result);
        }
    }
}