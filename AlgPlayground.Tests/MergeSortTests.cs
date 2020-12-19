using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using AlgPlayGroundApp.LeetCode.Easy;
using AlgPlayGroundApp.Sorting;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class MergeSortTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSorting()
        {
            var arr = new int[] {9, 5, 3, 2, 1, 7, 6, 4, 11};
            var result = new MergeSortFromLeet.Solution().MergeSort(arr);
            Assert.AreEqual(new int[]{1,2,3,4,5,6,7,9, 11}, result);
        }

    }



}