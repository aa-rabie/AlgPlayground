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
    public class BinarySearchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestItemIsFoundIfItExists()
        {
           var tmp = new BinarySearch();
           var data = new int[] { 5894, 6968, 5858, 8772, 745, 1893, 672, 4611, 5054, 3254, 3748, 5874, 2663, 273, 8507, 4604, 4654, 6342, 3567, 5108, 1113, 8589, 3232, 5402, 2326, 6313, 3594, 628, 4846, 3977, 9795, 1894, 9763, 6660, 9707, 3116, 3555, 3290, 4891, 5597, 580, 807, 1497, 2408, 1112, 1, 6832, 1143, 9320, 4279, 8938, 5248, 7322, 5697, 8711, 9392, 2397, 2100, 4341, 7472, 7002, 4893, 8968, 626, 1602, 5379, 5536, 19, 5396, 4231, 9847, 3752, 5621, 7012, 1986, 3090, 1383, 6257, 9501, 7004 };
           var actual = tmp.Search(data, 7004);
           var expected = 7004;
           Assert.That(actual, Is.EqualTo(expected));
        }
    }



}