using System;
using System.Collections.Generic;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class IntegerToRomanNumberTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(58, "LVIII")]
        [TestCase(1994, "MCMXCIV")]
        [TestCase(1996, "MCMXCVI")]
        public void TestMySolution(int num, string expectedResult)
        {
           var result = new IntToRomanNumberConverter.MySolution().IntToRoman(num);
           Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(58, "LVIII")]
        [TestCase(1994, "MCMXCIV")]
        [TestCase(1996, "MCMXCVI")]
        public void TestLeetSolution(int num, string expectedResult)
        {
            var result = new IntToRomanNumberConverter.LeetSolution().IntToRoman(num);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }



}