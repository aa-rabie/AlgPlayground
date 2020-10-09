using System.Linq;

namespace AlgPlayGroundApp.LeetCode.Arrays
{
    // problem => https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/567/
    // solution => https://leetcode.com/problems/move-zeroes/solution/
    public class MoveZeroToEndInPlace
    {
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || !nums.Any()) return;

            int i = 0;
            //int zeroCount = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    nums[i++] = nums[j];
                   
                }
            }

            for (int j = i; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }
    }
}