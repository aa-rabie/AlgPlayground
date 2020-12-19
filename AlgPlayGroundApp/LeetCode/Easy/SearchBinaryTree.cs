namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/search-in-a-binary-search-tree/
    /// solution: https://leetcode.com/problems/search-in-a-binary-search-tree/solution/
    /// </summary>
    public class SearchBinaryTree
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
            public TreeNode SearchBST(TreeNode root, int val)
            {
                TreeNode node = null;
                if (root == null)
                    return null;

                if (root.Val == val)
                    return root;


                if (root.Left != null && val < root.Val)
                {
                    node = SearchBST(root.Left,val);
                    if (node != null)
                        return node;
                }

                if (root.Right != null && val >= root.Val)
                {
                    node = SearchBST(root.Right, val);
                    if (node != null)
                        return node;
                }

                return null;

            }
        }
    }

}