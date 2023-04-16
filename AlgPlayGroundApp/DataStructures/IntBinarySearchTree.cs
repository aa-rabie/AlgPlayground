using System;

namespace AlgPlayGroundApp.DataStructures
{
    public class IntBinarySearchTree : BinarySearchTree<int>
    {
        public bool IsValidBinarySearchTree()
        {
            return CheckIfValidBST(Root, null, null);
        }

        protected bool CheckIfValidBST(Node root, int? low, int? high)
        {
            if (root == null)
            {
                return true;
            }
            // The current node's value must be between low and high.
            if ((low != null && root.Value <= low) || (high != null && root.Value >= high))
            {
                return false;
            }
            // The left and right subtree must also be valid.
            return CheckIfValidBST(root.RightChild, root.Value, high) &&
                   CheckIfValidBST(root.LeftChild, low, root.Value);
        }
    }
}