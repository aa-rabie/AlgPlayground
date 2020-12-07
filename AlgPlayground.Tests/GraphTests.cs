using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class GraphTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTopologicalOrder()
        {
           var graph = new Graph();
          graph.AddNode("x");
          graph.AddNode("a");
          graph.AddNode("b");
          graph.AddNode("p");
          graph.AddEdge("x","a");
          graph.AddEdge("x","b");
          graph.AddEdge("a","p");
          graph.AddEdge("b","p");

          var sorted = graph.TopologicalOrder();
          StringAssert.AreEqualIgnoringCase(sorted[0],"x");
          StringAssert.AreEqualIgnoringCase(sorted[3],"p");
          Assert.True(sorted[1] == "a" || sorted[1] == "b");
          Assert.True(sorted[2] == "a" || sorted[2] == "b");
        }

        [Test]
        public void TestHasCycleReturnFalseForGraphWithoutCycle()
        {
            var graph = new Graph();
            graph.AddNode("x");
            graph.AddNode("a");
            graph.AddNode("b");
            graph.AddNode("p");
            graph.AddEdge("x", "a");
            graph.AddEdge("x", "b");
            graph.AddEdge("a", "p");
            graph.AddEdge("b", "p");

            var result = graph.HasCycle();
           
            Assert.False(result);
        }

        [Test]
        public void TestHasCycleReturnTrueForGraphWithCycle()
        {
            var graph = new Graph();
            graph.AddNode("x");
            graph.AddNode("a");
            graph.AddNode("b");
            graph.AddNode("p");
            graph.AddEdge("x", "a");
            graph.AddEdge("x", "b");
            graph.AddEdge("a", "p");
            graph.AddEdge("p", "x");

            var result = graph.HasCycle();

            Assert.True(result);
        }
    }

}