using System;

namespace AlgPlayGroundApp.DataStructures
{
    public class IntBinarySearchTree : BinarySearchTree<int>
    {
        public bool IsValidBinarySearchTree()
        {
            return IsValidBinarySearchTree(Root, int.MinValue, int.MaxValue);
        }

        protected bool IsValidBinarySearchTree(Node root, int minValidValue, int maxValidValue)
        {
            if (root == null)
                return true;

            if (root.Value < minValidValue || root.Value > maxValidValue)
                return false;

            return IsValidBinarySearchTree(root.LeftChild, minValidValue, root.Value - 1)
                   && IsValidBinarySearchTree(root.RightChild, root.Value + 1, maxValidValue);
        }
    }
}