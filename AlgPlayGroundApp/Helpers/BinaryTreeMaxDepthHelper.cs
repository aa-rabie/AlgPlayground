using System;

namespace AlgPlayGroundApp.Helpers
{
    // source => https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/535/

    public class BinaryTreeMaxDepthHelper
    {
        public class TreeNode
        {
            public int Val;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.Val = val;
                this.Left = left;
                this.Right = right;
            }
        }

        public int MaxDepth(TreeNode root)
        {
            return CalcDepth(root);
        }

        private int CalcDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(CalcDepth(node.Left), CalcDepth(node.Right));
        }
    }
}