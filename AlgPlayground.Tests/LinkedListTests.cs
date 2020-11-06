using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class LinkedListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEnumerator()
        {
            //arrange
            var arr = new List<int>(){1,2,4};
            AlgPlayGroundApp.DataStructures.LinkedList<int> list = new AlgPlayGroundApp.DataStructures.LinkedList<int>();
            foreach (var val in arr)
            {
                list.AddLast(val);
            }

            int index = 0;
            foreach (var entry in list)
            {
                if(index >= arr.Count)
                    throw new IndexOutOfRangeException();

                Assert.AreEqual(arr[index++], entry);
            }

        }

        [Test]
        public void TestEmptyEnumerator()
        {
            //arrange
            AlgPlayGroundApp.DataStructures.LinkedList<int> list = new AlgPlayGroundApp.DataStructures.LinkedList<int>();
            Assert.IsEmpty(list);
        }

        [Test]
        public void TestRemoveNodeWhenListHasSingleElement()
        {
            //arrange
            AlgPlayGroundApp.DataStructures.LinkedList<int> list = new AlgPlayGroundApp.DataStructures.LinkedList<int>();
            list.AddFirst(5);
            list.Remove(5);
            Assert.IsEmpty(list);
        }

        [Test]
        public void TestRemoveNodeInTheMiddleWhenListHasMultiple()
        {
            //arrange
            AlgPlayGroundApp.DataStructures.LinkedList<int> list = new AlgPlayGroundApp.DataStructures.LinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.Remove(6);
            Assert.AreEqual( new int[]{5,7}, list.ToArray());
        }

        [Test]
        public void TestRemoveLastNodeWhenListHasMultiple()
        {
            //arrange
            AlgPlayGroundApp.DataStructures.LinkedList<int> list = new AlgPlayGroundApp.DataStructures.LinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.Remove(7);
            Assert.AreEqual(new int[] { 5, 6 }, list.ToArray());
        }


        [Test]
        public void TestRemoveFirrstNodeWhenListHasMultiple()
        {
            //arrange
            AlgPlayGroundApp.DataStructures.LinkedList<int> list = new AlgPlayGroundApp.DataStructures.LinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.Remove(5);
            Assert.AreEqual(new int[] { 6, 7 }, list.ToArray());
        }
    }

}