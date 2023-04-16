namespace AlgPlayGroundApp.Helpers
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/data-structure-tree/17/solve-problems-recursively/537/
    /// https://leetcode.com/problems/path-sum/editorial/
    /// </summary>
    public class BinaryTreePathSumChecker
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

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            return PathSumExists(root, targetSum);
        }

        private static bool PathSumExists(TreeNode node, int targetSum)
        {
            if (node == null)
                return false;

            if (node.Left == null && node.Right == null)
                return node.Val == targetSum;


            return PathSumExists(node.Left, targetSum - node.Val)
                   || PathSumExists(node.Right, targetSum - node.Val);
        }
    }
}