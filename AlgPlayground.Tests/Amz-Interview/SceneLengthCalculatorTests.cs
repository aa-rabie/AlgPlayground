using System;
using System.Collections.Generic;
using AlgPlayGroundApp.Amazon.Demo;
using AlgPlayGroundApp.Amazon.Jordan;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class SceneLengthCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var calc = new SceneLengthCalculator();
            var result = calc.CalculateEachSceneLength(new List<char>() {'a', 'b', 'c'});
            Assert.AreEqual(result, new List<int>(){1,1,1});

            result = calc.CalculateEachSceneLength(new List<char>() { 'a', 'b', 'c' , 'a'});
            Assert.AreEqual(result, new List<int>() { 4 });

            result = calc.CalculateEachSceneLength(new List<char>() { 'a', 'b', 'a', 'b', 'c', 'b', 'a', 'c', 'a', 'd', 'e', 'f', 'e','g','d','e', 'h', 'i', 'j', 'h', 'k', 'l', 'i', 'j' });
            Assert.AreEqual(result, new List<int>() { 9,7,8 });
        }

    }

}