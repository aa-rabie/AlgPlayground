using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class WeightedGraphTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetShortedPath()
        {
           var graph = new WeightedGraph();
          graph.AddNode("a");
          graph.AddNode("b");
          graph.AddNode("c");
          graph.AddNode("p");
          graph.AddEdge("a","b", 1);
          graph.AddEdge("b","c", 2);
          graph.AddEdge("a","c", 10);

          var path = graph.GetShortedPath("a", "c");
          StringAssert.AreEqualIgnoringCase("a,b,c",path.ToString());
          
        }

        [Test]
        public void TestHasCycleReturnFalseForCorrectGraph()
        {
            var graph = new WeightedGraph();
            graph.AddNode("a");
            graph.AddNode("b");
            graph.AddNode("c");
            graph.AddNode("p");
            graph.AddEdge("a", "b", 0);
            graph.AddEdge("b", "c", 0);
            var hasCycle = graph.HasCycle();
            Assert.That(false, Is.EqualTo(hasCycle));

        }

        [Test]
        public void TestHasCycleReturnTrueIfThereIsCycle()
        {
            var graph = new WeightedGraph();
            graph.AddNode("a");
            graph.AddNode("b");
            graph.AddNode("c");
            graph.AddNode("p");
            graph.AddEdge("a", "b", 0);
            graph.AddEdge("b", "c", 0);
            graph.AddEdge("c", "a", 0);
            var hasCycle = graph.HasCycle();
            Assert.That(true, Is.EqualTo(hasCycle));

        }

    }

}