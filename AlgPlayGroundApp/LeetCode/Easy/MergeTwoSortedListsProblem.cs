using System;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    public class MergeTwoSortedListsProblem
    {
        public class ListNode
        {
            public int Val;
            public ListNode Next;

            public ListNode(int Val = 0, ListNode Next = null)
            {
                this.Val = Val;
                this.Next = Next;
            }

        }

        public class MySolution
        {
            public ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                if(l1 == null && l2 == null)
                    return null;
                else if (l1 == null)
                    return l2;
                else if (l2 == null)
                    return l1;

                ListNode l1Current = l1, l2Current = l2;
                ListNode result = null;
                ListNode parentNode = result;
                while (l1Current != null || l2Current != null)
                {
                    if (l1Current == null)
                    {
                        parentNode = AddValueToResultList(parentNode,l2Current);
                        l2Current = MoveNext(l2Current);
                    }
                    else if (l2Current == null)
                    {
                        parentNode = AddValueToResultList(parentNode,l1Current);
                        l1Current = MoveNext(l1Current);
                    }
                    else
                    {
                        if (l1Current.Val < l2Current.Val)
                        {
                            parentNode = AddValueToResultList(parentNode,l1Current);
                            l1Current = MoveNext(l1Current);
                        }
                        else
                        {
                            parentNode = AddValueToResultList(parentNode, l2Current);
                            l2Current = MoveNext(l2Current);
                        }
                    }
                }

                return result;

                ListNode AddValueToResultList(ListNode parent, ListNode Next)
                {
                    if (result == null)
                    {
                        result = new ListNode(Next.Val);
                        return result;
                    }
                    else
                    {
                        parent.Next = new ListNode(Next.Val);
                        return parent.Next;
                    }
                }

                ListNode MoveNext(ListNode node)
                {
                    if(node == null || node.Next == null)
                        return null;

                    return node.Next;
                }
            }
        }

        public class LeetSolution
        {
            public ListNode MergeTwoListsRecursively(ListNode l1, ListNode l2)
            {
                if (l1 == null)
                {
                    return l2;
                }
                else if (l2 == null)
                {
                    return l1;
                }
                else if (l1.Val < l2.Val)
                {
                    l1.Next = MergeTwoListsRecursively(l1.Next, l2);
                    return l1;
                }
                else
                {
                    l2.Next = MergeTwoListsRecursively(l1, l2.Next);
                    return l2;
                }

            }
        }
    }
}