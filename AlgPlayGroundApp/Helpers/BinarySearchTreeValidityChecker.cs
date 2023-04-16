using System;

namespace AlgPlayGroundApp.Helpers
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/140/introduction-to-a-bst/997/
    /// https://leetcode.com/problems/validate-binary-search-tree/editorial/
    /// </summary>
    public class BinarySearchTreeValidityChecker
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public bool IsValidBST(TreeNode root)
        {
            return CheckIfValidBST(root, null , null);
        }

        protected bool CheckIfValidBST(TreeNode root, int? low, int? high)
        {
            if (root == null)
            {
                return true;
            }
            // The current node's value must be between low and high.
            if ((low != null && root.val <= low) || (high != null && root.val >= high))
            {
                return false;
            }
            // The left and right subtree must also be valid.
            return CheckIfValidBST(root.right, root.val, high) && CheckIfValidBST(root.left, low, root.val);
        }

        public static void Test()
        {
            // [-2147483648,-2147483648]
            var root = new TreeNode(-2147483648, new TreeNode(-2147483648));
            Console.WriteLine(new BinarySearchTreeValidityChecker().IsValidBST(root));
        }
    }
}