using System;
using System.Collections.Generic;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class KthLargestValueGetterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 8)]
        [TestCase(2, 5)]
        [TestCase(6, 1)]
        public void TestKthLargestValue(int k, int expectedResult)
        {
           int[] data = new int[]{5,3,8,4,1,2};
           var result = ArrayHelper.GetKthLargestValue(data, k);
           Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(0, typeof(ArgumentOutOfRangeException))]
        [TestCase(7, typeof(ArgumentOutOfRangeException))]
        public void TestKthLargestValueThrowsWithInvalidException(int k, Type expectedExceptionType)
        {
            int[] data = new int[] { 5, 3, 8, 4, 1, 2 };
            Assert.Throws(expectedExceptionType, () => ArrayHelper.GetKthLargestValue(data, k));
        }
    }



}