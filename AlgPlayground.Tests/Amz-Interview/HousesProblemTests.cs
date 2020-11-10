using System;
using AlgPlayGroundApp.Amazon.Demo;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class HousesProblemTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var initialState = new int[] {1, 0, 0, 0, 0, 1, 0, 0};
            var result = new int[] { 0,1,0,0,1,0,1,0};
            var h = new AlgPlayGroundApp.Amazon.Demo.HousesProblem();
            var actual = h.CellComplete(initialState, 1);
            Assert.AreEqual(result, actual);

            initialState = new int[] { 1,1,1,0,1,1,1,1 };
            result = new int[] { 0,0,0,0,0,1,1,0};
            actual = h.CellComplete(initialState, 2);
            Assert.AreEqual(result, actual);
        }

    }

}