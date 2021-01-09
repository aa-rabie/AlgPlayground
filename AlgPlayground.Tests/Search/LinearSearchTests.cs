using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using AlgPlayGroundApp.Searching;
using AlgPlayGroundApp.Sorting;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class LinearSearchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestItemIsFoundIfItExists()
        {
           var tmp = new LinearSearch<int>();
           var data = new int[] {1, 5, 2, 9, 6, 6, 4, 2};
           var actual = tmp.Search(data, 1);
           var expected = 0;
           Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestWhenItemDoesNotExistItReturnMinusOne()
        {
            var tmp = new LinearSearch<int>();
            var data = new int[] { 1, 5, 2, 9, 6, 6, 4, 2 };
            var actual = tmp.Search(data, -1);
            var expected = -1;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestItReturnMinusOneWhenArrayIsEmpty()
        {
            var tmp = new LinearSearch<int>();
            var data = new int[] { };
            var actual = tmp.Search(data, -1);
            var expected = -1;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestItReturnMinusOneWhenArrayIsNull()
        {
            var tmp = new LinearSearch<int>();
            
            var actual = tmp.Search(null, -1);
            var expected = -1;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }



}