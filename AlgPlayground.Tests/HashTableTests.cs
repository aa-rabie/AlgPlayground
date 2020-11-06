using System;
using System.Collections.Generic;
using AlgPlayGroundApp.DataStructures;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class HashTableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPut()
        {
           HashTable table = new HashTable(5);
           table.Put(6,"A");
           table.Put(11,"B");
           table.Put(100,"C");
           
           Assert.AreEqual("A" , table.Get(6));
           Assert.AreEqual("B", table.Get(11));
           Assert.AreEqual("C", table.Get(100));
        }

        [Test]
        public void TestPutWithDuplicateKey()
        {
            HashTable table = new HashTable(5);
            table.Put(6, "A");
            table.Put(6, "B");
            
            Assert.AreEqual("B", table.Get(6));
        }

        [Test]
        public void TestRemove()
        {
            HashTable table = new HashTable(5);
            table.Put(6, "A");
            table.Put(16, "y");

            var val = table.Get(16);
            table.Remove(16);
            Assert.AreEqual("y", val);

            val = table.Get(6);
            table.Remove(6);
            Assert.AreEqual("A", val);
        }
    }

}