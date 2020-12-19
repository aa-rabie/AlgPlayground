namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/solution/
    /// </summary>
    public class BinaryTreeMaxDepthCalculator
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

        public class Solution
        {
            public int MaxDepth(TreeNode root)
            {
                if (root == null)
                    return 0;
                var leftSubTreeDepth = MaxDepth(root.Left);
                var rightSubTreeDepth = MaxDepth(root.Right);

                return 1 + (leftSubTreeDepth > rightSubTreeDepth ? leftSubTreeDepth : rightSubTreeDepth);
            }
        }
    }
}