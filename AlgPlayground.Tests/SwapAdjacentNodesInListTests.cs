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
    public class SwapAdjacentNodesInListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNonEmptyStringIsReversedCorrectly()
        {
            SwapAdjacentNodesInList.ListNode input = new SwapAdjacentNodesInList.ListNode(1,
                new SwapAdjacentNodesInList.ListNode(2, 
                    new SwapAdjacentNodesInList.ListNode(3, 
                        new SwapAdjacentNodesInList.ListNode(4))));

            SwapAdjacentNodesInList.ListNode expected = new SwapAdjacentNodesInList.ListNode(2,
                new SwapAdjacentNodesInList.ListNode(1,
                    new SwapAdjacentNodesInList.ListNode(4,
                        new SwapAdjacentNodesInList.ListNode(3))));

            var result = new SwapAdjacentNodesInList.Solution().SwapPairs(input);

            Assert.AreEqual(input.Val, result.Next.Val);

        }

    }



}