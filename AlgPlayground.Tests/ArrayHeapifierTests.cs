using System;
using System.Collections.Generic;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class ArrayHeapifierTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIHeapify()
        {
           int[] data = new int[]{5,3,8,4,1,2};
           ArrayHeapifier.Heapify(data);
           Assert.That(data[0], Is.EqualTo(8));
           Assert.That(data[1], Is.EqualTo(4));
           Assert.That(data[2], Is.EqualTo(5));
           Assert.That(data[3], Is.EqualTo(3));
           Assert.That(data[4], Is.EqualTo(1));
           Assert.That(data[5], Is.EqualTo(2));
        }
    }



}