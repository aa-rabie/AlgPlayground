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
    public class ExponentialSearchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSearch()
        {
           var tmp = new ExponentialSearch();
           var data = new int[] {1, 2, 3 , 5 , 7};
           var actual = tmp.Search(data, 7);
           Assert.That(actual, Is.EqualTo(4));

           data = new int[] { 1, 2 };
           actual = tmp.Search(data, 2);
           Assert.That(actual, Is.EqualTo(1));

           actual = tmp.Search(data, 21);
           Assert.That(actual, Is.EqualTo(-1));

           data = new int[] { 1 };
            actual = tmp.Search(data, 1);
           Assert.That(actual, Is.EqualTo(0));

           actual = tmp.Search(data, 11);
           Assert.That(actual, Is.EqualTo(-1));

           data = new int[] {  };
           actual = tmp.Search(data, 1);
           Assert.That(actual, Is.EqualTo(-1));

           actual = tmp.Search(null, 1);
           Assert.That(actual, Is.EqualTo(-1));
        }
    }



}