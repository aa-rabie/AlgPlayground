using System;
using System.Collections.Generic;
using System.Text;

namespace AlgPlayGroundApp.DataStructures
{
    class AvlTree
    {
        public class AvlNode
        {
            public AvlNode(int value)
            {
                this.Value = value;
            }
            public int Value { get; set; }
            public AvlNode LeftChild { get; set; }
            public AvlNode RightChild { get; set; }
            public int Height { get; internal set; }

            public override string ToString()
            {
                return $"{nameof(AvlNode)} = {Value}";
            }
        }

        public AvlNode Root { get; private set; }

        public void Insert(int val)
        {
           Root = Insert(Root, val);
        }

        private AvlNode Insert(AvlNode root, int val)
        {
            AvlNode node = new AvlNode(val);
            if (root == null)
            {
                return node;
            }

            if (val < root.Value)
            {
                //goto to left sub-tree
                root.LeftChild = Insert(root.LeftChild, val);
            }
            else
            {
                //goto to right sub-tree
                root.RightChild = Insert(root.RightChild, val);
            }

            SetHeight(root);

            return Balance(root);
        }

        private AvlNode Balance(AvlNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (CalculateBalanceFactor(root.LeftChild) < 0)
                {
                    Console.WriteLine($"Left Rotation on {root.LeftChild.Value}");
                    root.LeftChild = RotateLeft(root.LeftChild);
                }

                Console.WriteLine($"Right Rotation on {root.Value}");
                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (CalculateBalanceFactor(root.RightChild) > 0)
                {
                    Console.WriteLine($"Right Rotation on {root.RightChild.Value}");
                    root.RightChild = RotateRight(root.RightChild);
                }

                Console.WriteLine($"Left Rotation on {root.Value}");
                return RotateLeft(root);
            }
            //if balanced then return same root
            return root;
        }

        private int GetHeight(AvlNode node) => node?.Height ?? -1;

        private void SetHeight(AvlNode node)
        {
            node.Height = Math.Max(GetHeight(node.LeftChild), GetHeight(
                       node.RightChild)) + 1;
        }

        private int CalculateBalanceFactor(AvlNode node) => node == null ? 0 : GetHeight(node.LeftChild) - GetHeight(node.RightChild);

        private bool IsLeftHeavy(AvlNode node) => CalculateBalanceFactor(node) > 1;

        private bool IsRightHeavy(AvlNode node) => CalculateBalanceFactor(node) < -1;

        private AvlNode RotateLeft(AvlNode root)
        {
            var newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private AvlNode RotateRight(AvlNode root)
        {
            var newRoot = root.LeftChild;
            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }
    }
}
