using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using AlgPlayGroundApp.Sorting;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class QuickSortTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUnSortedArrayIsSortedCorrectly()
        {
           var tmp = new QuickSort<int>();
           var actual = new int[] { 10, 80, 30, 90, 40, 50, 70 };
           tmp.Sort(actual);
           var expected = new int[] { 10, 30, 40, 50, 70, 80, 90 };
           Assert.That(actual, Is.EqualTo(expected));
        }
    }



}