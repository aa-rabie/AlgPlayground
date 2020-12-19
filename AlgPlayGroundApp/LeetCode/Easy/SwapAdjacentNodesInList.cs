namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/recursion-i/250/principle-of-recursion/1681/
    /// Solution => https://leetcode.com/problems/swap-nodes-in-pairs/solution/
    /// Given a linked list, swap every two adjacent nodes and return its head.

    /// You may not modify the values in the list's nodes. Only nodes itself may be changed.
    /// </summary>
    public class SwapAdjacentNodesInList
    {
        public class ListNode
        {
            public int Val;
            public ListNode Next;

            public ListNode(int val = 0, ListNode Next = null)
            {
                this.Val = val;
                this.Next = Next;
            }

        }

        public class Solution
        {
            public ListNode SwapPairs(ListNode head)
            {
                if (head == null || head.Next == null)
                    return head;

                // Nodes to be swapped
                ListNode firstNode = head;
                ListNode secondNode = head.Next;

                // Swapping
                firstNode.Next = SwapPairs(secondNode.Next);
                secondNode.Next = firstNode;

                // Now the head is the second node
                return secondNode;

            }
        }
    }
}