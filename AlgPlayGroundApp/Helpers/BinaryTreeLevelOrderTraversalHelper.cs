using System.Collections.Generic;

namespace AlgPlayGroundApp.Helpers
{
    /// <summary>
    /// source: https://leetcode.com/explore/learn/card/data-structure-tree/134/traverse-a-tree/931/
    /// solution : https://leetcode.com/problems/binary-tree-level-order-traversal/editorial/
    /// 
    /// </summary>
    public class BinaryTreeLevelOrderTraversalHelper
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

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var list = new List<IList<int>>();
            if (root == null)
            {
                return list;
            }
            Traverse(list, root, 0);
            return list;
        }

        private void Traverse(List<IList<int>> final, TreeNode node, int level)
        {
            if (node == null)
                return;

            if (final.Count == level)
            {
                // add new level
                final.Add(new List<int>());
            }

            final[level].Add(node.Val);

            if (node.Left != null)
                Traverse(final, node.Left, level + 1);
            if (node.Right != null)
                Traverse(final, node.Right, level + 1);
        }
    }
}