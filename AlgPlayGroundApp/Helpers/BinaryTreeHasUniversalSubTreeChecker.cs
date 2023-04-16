using System;

namespace AlgPlayGroundApp.Helpers
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/538/
    /// https://leetcode.com/problems/count-univalue-subtrees/editorial/
    /// </summary>
    public class BinaryTreeHasUniversalSubTreeChecker
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

        public int CountUnivalSubtrees(TreeNode root)
        {
            var count = 0;
            if (root == null)
                return count;

            is_uni(root, ref count);
            return count;
        }

        bool is_uni(TreeNode node, ref int count)
        {
            //base case - if the node has no children this is a univalue subtree
            if (node.left == null && node.right == null)
            {

                // found a univalue subtree - increment
                count++;
                return true;
            }

            bool is_unival = true;

            // check if all of the node's children are univalue subtrees and if they have the same value
            // also recursively call is_uni for children
            if (node.left != null)
            {
                is_unival = is_uni(node.left, ref count) && is_unival && node.left.val == node.val;
            }

            if (node.right != null)
            {
                is_unival = is_uni(node.right, ref count) && is_unival && node.right.val == node.val;
            }

            // return if a univalue tree exists here and increment if it does
            if (!is_unival) 
                return false;

            count++;

            return true;
        }

        internal static void Test()
        {
            var left = new TreeNode(1, new TreeNode(1), new TreeNode(1));
            var right = new TreeNode(3, new TreeNode(1));
            var root = new TreeNode(5, left, right);

            Console.WriteLine(new BinaryTreeHasUniversalSubTreeChecker().CountUnivalSubtrees(root));
        }
    }
}