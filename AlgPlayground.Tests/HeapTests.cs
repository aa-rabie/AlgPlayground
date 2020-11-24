using System;
using System.Collections.Generic;
using AlgPlayGroundApp.DataStructures;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class HeapTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInsert()
        {
           var heap = new Heap<int>(5);
           heap.Insert(10);
           heap.Insert(5);
           heap.Insert(17);
           heap.Insert(4);
           heap.Insert(22);

           Assert.That(heap.Array[0], Is.EqualTo(22));
           Assert.That(heap.Array[1], Is.EqualTo(17));
           Assert.That(heap.Array[2], Is.EqualTo(10));
           Assert.That(heap.Array[3], Is.EqualTo(4));
           Assert.That(heap.Array[4], Is.EqualTo(5));
        }

        [Test]
        public void TestRemove()
        {
            var heap = new Heap<int>(5);
            heap.Insert(10);
            heap.Insert(5);
            heap.Insert(17);
            heap.Insert(4);
            heap.Insert(22);
            var removedValue = heap.Remove();
            Assert.That(heap.Array[0], Is.EqualTo(17));
            Assert.That(heap.Array[1], Is.EqualTo(5));
            Assert.That(heap.Array[2], Is.EqualTo(10));
            Assert.That(heap.Array[3], Is.EqualTo(4));
            Assert.That(heap.Size,Is.EqualTo(4));
            Assert.That(removedValue, Is.EqualTo(22));
        }
    }



}