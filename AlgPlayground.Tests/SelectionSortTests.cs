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
    public class SelectionSortTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUnSortedArrayIsSortedCorrectly()
        {
           var tmp = new SelectionSort<int>();
           var actual = new int[] {1, 5, 2, 9, 6, 6, 4, 2};
           tmp.Sort(actual);
           var expected = new int[] {1, 2, 2, 4, 5, 6, 6, 9};
           Assert.That(actual, Is.EqualTo(expected));
        }
    }



}