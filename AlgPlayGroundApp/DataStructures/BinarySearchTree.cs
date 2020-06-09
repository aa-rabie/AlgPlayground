using System;

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
            if (root.LeftChild == null && root.RightChild == null)
                return 0;

            return 1 + Math.Max(CalculateHeight(root.LeftChild), CalculateHeight(root.RightChild));
        }

        public int Height() => CalculateHeight(Root);
    }
}