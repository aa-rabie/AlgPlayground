using System;
using System.Text;
using AlgPlayGroundApp.DataStructures;
using AlgPlayGroundApp.Helpers;
using NUnit.Framework;

namespace AlgPlayground.Tests
{
    public class BinarySearchTreeTraversalHelperTests
    {
        [Test]
        public void TestTraverseLevelOrderWhenTreeHasData()
        {
            var tree = new IntBinarySearchTree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);

            BinarySearchTreeTraversalHelper helper = new BinarySearchTreeTraversalHelper();
            StringBuilder builder = new StringBuilder();
            void WriteValue(int val)
            {
                builder.Append($"{val},");
            }

            helper.TraverseLevelOrder(tree , WriteValue);

            Assert.AreEqual("7,4,9,1,6,8,10,", builder.ToString());
        }

        [Test]
        public void TestTraverseLevelOrderWhenTreeIsEmptyShouldWriteNothing()
        {
            var tree = new IntBinarySearchTree();
            BinarySearchTreeTraversalHelper helper = new BinarySearchTreeTraversalHelper();
            StringBuilder builder = new StringBuilder();
            void WriteValue(int val)
            {
                builder.Append($"{val},");
            }

            helper.TraverseLevelOrder(tree, WriteValue);

            Assert.AreEqual("", builder.ToString());
        }
    }
}