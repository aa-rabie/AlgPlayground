using System;
using AlgPlayGroundApp.DataStructures;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class ArrayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRemoveTheLastIndexWillMakeCountZero()
        {
            var arr = new Array<int>(1);
            arr.Add(10);
            arr.RemoveAt(0);
            Assert.AreEqual(0, arr.Count);
        }

        [Test]
        public void TestRemove1stElementWillKeep2ndElm()
        {
            var arr = new Array<int>(2);
            arr.Add(10);
            arr.Add(20);
            arr.RemoveAt(0);
            
            Assert.AreEqual("[20]", arr.ToString());
            Assert.AreEqual(1, arr.Count);
        }

        [Test]
        public void TestRemove2stElementWillKeep1ndElm()
        {
            var arr = new Array<int>(2);
            arr.Add(10);
            arr.Add(20);
            arr.RemoveAt(1);
            var actual = arr.ToString();
            Assert.AreEqual("[10]", actual);
            Assert.AreEqual(1, arr.Count);
        }

        [Test]
        public void TestRemoveAt()
        {
            var arr = new Array<int>(2);
            arr.Add(10);
            arr.Add(20);
            arr.Add(30);
            arr.RemoveAt(1);
            var actual = arr.ToString();
            Assert.AreEqual("[10,30]", actual);
            Assert.AreEqual(2, arr.Count);
        }

    }

}