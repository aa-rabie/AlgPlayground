using System;
using AlgPlayGroundApp.DataStructures;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class ArrayUsingTwoStacksTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEnqueue()
        {
            var queue = new QueueUsingTwoStacks<int>();
            queue.Enqueue(10);
            Assert.AreEqual(false, queue.IsEmpty);
        }

        [Test]
        public void TestDequeue()
        {
            var queue = new QueueUsingTwoStacks<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            var item = queue.Dequeue();
            Assert.AreEqual(10, item);
            item = queue.Dequeue();
            item = queue.Dequeue();
            Assert.AreEqual(30, item);
            Assert.AreEqual(true, queue.IsEmpty);
        }

        [Test]
        public void TestDequeueEmptyQueueThrows()
        {
            var queue = new QueueUsingTwoStacks<int>();
            var ex = Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            Assert.AreEqual("Queue is empty", ex.Message);
        }

        
    }

}