namespace AlgPlayGroundApp.Helpers
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/536/
    /// https://leetcode.com/problems/symmetric-tree/editorial/
    /// </summary>
    public class BinaryTreeSymmetricChecker
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

        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root.Left, root.Right);
        }

        private static bool IsMirror(TreeNode left, TreeNode right)
        {

            if (left == null && right == null)
                return true;

            if (left == null || right == null)
                return false;

            return
                left.Val == right.Val
                && IsMirror(left.Left, right.Right)
                && IsMirror(left.Right, right.Left);
        }
    }
}