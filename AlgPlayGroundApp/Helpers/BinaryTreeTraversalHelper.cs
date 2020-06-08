﻿using System;
using AlgPlayGroundApp.DataStructures;

namespace AlgPlayGroundApp.Helpers
{
    public class BinaryTreeTraversalHelper
    {
        public void TraversePreOrder<T>(BinaryTree<T>.Node root, Action<T> valWriter) where T : IComparable<T>
        {
            if (root == null)
                return;

            valWriter?.Invoke(root.Value);
            TraversePreOrder<T>(root.LeftChild,valWriter);
            TraversePreOrder<T>(root.RightChild,valWriter);
        }

        /// <summary>
        /// Traversing inOrder will Print values in ascending order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="valWriter"></param>
        public void TraverseInOrder<T>(BinaryTree<T>.Node root, Action<T> valWriter) where T : IComparable<T>
        {
            if (root == null)
                return;

            TraverseInOrder<T>(root.LeftChild, valWriter);
            valWriter?.Invoke(root.Value);
            TraverseInOrder<T>(root.RightChild, valWriter);
        }

        /// <summary>
        /// This method print tree value in descending order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="valWriter"></param>
        public void TraverseInOrderReversed<T>(BinaryTree<T>.Node root, Action<T> valWriter) where T : IComparable<T>
        {
            if (root == null)
                return;

            TraverseInOrderReversed<T>(root.RightChild, valWriter);
            valWriter?.Invoke(root.Value);
            TraverseInOrderReversed<T>(root.LeftChild, valWriter);
        }

        /// <summary>
        /// Traversing Post Order will start traversing from tree leafs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="valWriter"></param>
        public void TraversePostOrder<T>(BinaryTree<T>.Node root, Action<T> valWriter) where T : IComparable<T>
        {
            if (root == null)
                return;

            TraversePostOrder<T>(root.LeftChild, valWriter);
            TraversePostOrder<T>(root.RightChild, valWriter);
            valWriter?.Invoke(root.Value);
        }
    }
}