using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class StringReverseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNonEmptyStringIsReversedCorrectly()
        {
            var input = new char[] {'h', 'e', 'l', 'l', 'o'};
            StringReverse.ReverseInPlace(input);
            
            var expected = new char[] {'o', 'l', 'l', 'e', 'h'};
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(input[i], expected[i]);
            }
        }

    }



}