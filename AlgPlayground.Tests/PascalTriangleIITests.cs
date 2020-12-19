using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using AlgPlayGroundApp.LeetCode.Easy;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class PascalTriangleIITests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetNthRow()
        {

            var result = new PascalTriangleII.Solution().GetRow(3);
            Assert.AreEqual(new List<int>(){1,3,3,1}, result);

        }

    }



}