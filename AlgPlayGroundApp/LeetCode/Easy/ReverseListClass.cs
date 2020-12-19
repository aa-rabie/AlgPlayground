using System;
using System.Collections.Generic;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/recursion-i/251/scenario-i-recurrence-relation/2378/
    /// solution : https://leetcode.com/problems/reverse-linked-list/solution/
    /// </summary>
    public class ReverseListClass
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

        public ListNode Reverse(ListNode head)
        {
            var current = head;
            ListNode prev = null;

            while (current != null)
            {
                var tempNext = current.Next;
                current.Next = prev;
                prev = current;
                current = tempNext;
            }

            return prev;
        }
        public ListNode ReverseRecursively(ListNode head)
        {
            if (head == null || head.Next == null)
                return head;

            ListNode p = ReverseRecursively(head.Next);
            head.Next.Next = head;
            head.Next = null;
            return p;
        }
    }
}