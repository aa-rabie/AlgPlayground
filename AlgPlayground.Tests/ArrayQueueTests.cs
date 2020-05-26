using System;
using AlgPlayGroundApp.DataStructures;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class ArrayQueueTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEnqueue()
        {
            var queue = new ArrayQueue<int>(5);
            queue.Enqueue(10);
            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void TestDequeue()
        {
            var queue = new ArrayQueue<int>(5);
            queue.Enqueue(10);
            var item = queue.Dequeue();
            Assert.AreEqual(10, item);
        }

        [Test]
        public void TestDequeueEmptyQueueThrows()
        {
            var queue = new ArrayQueue<int>(5);
            var ex = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.AreEqual("Queue is empty", ex.Message);
        }

        [Test]
        public void TestEnqueueFullQueueThrows()
        {
            var queue = new ArrayQueue<int>(1);
            queue.Enqueue(1);
            var ex = Assert.Throws<InvalidOperationException>(() => queue.Enqueue(2));
            Assert.AreEqual("Queue is full", ex.Message);
        }

        [Test]
        public void TestToStringReturnsCorrectValue()
        {
            var queue = new ArrayQueue<int>(10);
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.AreEqual("1,2", queue.ToString());
        }
    }

}