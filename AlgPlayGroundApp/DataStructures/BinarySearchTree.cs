using System;
using System.Collections.Generic;

namespace AlgPlayGroundApp.DataStructures
{
    /// <summary>
    /// Binary Search Tree
    /// left less than node && node less than Right
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public override string ToString()
            {
                return $"Node = {Value}";
            }
        }

        public Node Root { get; private set; }

        public void Insert(T val)
        {
            //creating new node object
            var node = new Node(val);

            if (Root == null)
            {
                //Tree is empty so add the new node as root node
                Root = node;
                return;
            }

            //Tree is not empty so let us search for parent node (under which new node will be inserted as a child node)
            var current = Root;
            while (current != null)
            {
                // if val < node then we continue searching in left sub tree
                if (node.Value.CompareTo(current.Value) <= 0)
                {
                    if (current.LeftChild == null)
                    {
                        // since Left Child is null then Current is Parent Node
                        current.LeftChild = node;
                        return;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    // val > node then we continue searching in right sub tree
                    if (current.RightChild == null)
                    {
                        // since Right Child is null then Current is Parent Node
                        current.RightChild = node;
                        return;
                    }
                    current = current.RightChild;
                }
            }
        }

        public bool Contains(T val)
        {
            var current = Root;
            while (current != null)
            {
                // val < node so continue searching with Left sub tree
                if (val.CompareTo(current.Value) < 0)
                {
                    current = current.LeftChild;
                }
                // val > node so continue searching with Left sub tree
                else if (val.CompareTo(current.Value) > 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    // we find the node
                    return true;
                }
            }
            // value not found in Tree
            return false;
        }

        /// <summary>
        /// equation => 1 + Max(Height(LeftChild), Height(RightChild))
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int CalculateHeight(Node root)
        {
            //tree is empty
            if(root == null)
                return -1;

            //this is a leaf node so its height is zero
            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(CalculateHeight(root.LeftChild), CalculateHeight(root.RightChild));
        }

        private bool IsLeaf(Node root) => root.LeftChild == null && root.RightChild == null;

        public int Height() => CalculateHeight(Root);

        public bool IsEmpty => Root == null;

        public T CalculateMinAsBinaryTree()
        {
            return CalculateMinAsBinaryTree(Root);
        }

        /// <summary>
        /// To Calculate the min value we need to go left most leaf node, it has the min value.
        /// O(Log N)
        /// </summary>
        /// <returns></returns>
        public T CalculateMinAsBinarySearchTree()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Tree is empty");

            if (IsLeaf(root: Root))
                return Root.Value;

            var current = Root;
            var previous = current;
            while (current != null)
            {
                previous = current;
                current = current.LeftChild;
            }

            return previous.Value;
        }

        /// <summary>
        /// This method can calculate Min Value for Normal BinaryTree not Only BinarySearchTree
        /// O(N) because it traverse all nodes in Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private T CalculateMinAsBinaryTree(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            if(root.LeftChild == null || root.RightChild == null)
                throw new InvalidOperationException("This is not a Binary Tree");

            var leftMin = CalculateMinAsBinaryTree(root.LeftChild);
            var rightMin = CalculateMinAsBinaryTree(root.RightChild);

            return MinValue(root.Value, MinValue(leftMin, rightMin));
        }

        private T MinValue(T left, T right)
        {
            if (left.CompareTo(right) <= 0)
                return left;

            return right;
        }

        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.Value.CompareTo(second.Value) == 0
                       && Equals(first.LeftChild, second.LeftChild)
                       && Equals(first.RightChild, second.RightChild);

            return false;
        }

        public bool Equals(BinarySearchTree<T> other)
        {
            if (other == null)
                return false;

            return Equals(Root, other.Root);
        }

        private void GetNodesAtDistance(Node root, int distance, List<T> values)
        {
            if(root == null || distance < 0)
                return;

            if (distance == 0)
            {
                //we reached required distance - so we add the value to list
                values?.Add(root.Value);
                return;
            }

            GetNodesAtDistance(root.LeftChild, distance - 1, values);
            GetNodesAtDistance(root.RightChild, distance - 1, values);
        }

        public List<T> GetNodesAtDistance(int distance)
        {
            List<T> values = new List<T>();
            GetNodesAtDistance(Root, distance, values);
            return values;
        }
    }
}