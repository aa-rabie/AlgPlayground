using System.Collections.Generic;

namespace AlgPlayGroundApp.LeetCode.Arrays
{
    // 
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/578/
    public class FindDuplicatesInArray
    {
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0) return false;

            System.Collections.Generic.HashSet<int> uniqueData = new HashSet<int>(nums.Length);
            foreach (var t in nums)
            {
                if (uniqueData.Contains(t))
                    return true;

                uniqueData.Add(t);
            }
            return false;
        }
    }
}