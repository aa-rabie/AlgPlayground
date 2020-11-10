using System;
using System.Collections.Generic;
using AlgPlayGroundApp.Amazon.Demo;
using AlgPlayGroundApp.Amazon.Jordan;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class FindMostUsedWordsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var text =
                "Jack and Jill went to the market to buy bread and cheese. Cheese is Jack's and Jill's favorite food.";
            var wordsToExclude = new List<string>(){"and", "he","the","to","is" };
            var h = new FindMostUsedWords();
            var result = h.RetrieveMostFrequentlyUsedWords(text, wordsToExclude);
            var expected = new List<string>() { "cheese", "jack", "jill", "s" };
            Assert.AreEqual(expected.Count,result.Count);
            foreach (var word in result)
            {
                Assert.IsTrue(expected.Contains(word));
            }
        }

    }

}