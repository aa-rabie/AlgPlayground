namespace AlgPlayGroundApp.LeetCode.Easy
{
    public class PalindromeListChecker
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

        public bool IsPalindrome(ListNode head)
        {
            // if list is empty or has single node return true
            if (head?.Next == null)
                return true;

           
            var current = head;
            var vals = new System.Collections.Generic.List<int>();
            while (current != null)
            {
                vals.Add(current.Val);
                current = current.Next;
            }

            var left = 0;
            var right = vals.Count - 1;
            while (left < right)
            {
                if (vals[left++] != vals[right--])
                    return false;
            }
            vals.Clear();
            return true;
        }
    }
}