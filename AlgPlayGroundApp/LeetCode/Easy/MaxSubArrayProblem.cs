using System;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-subarray/solution/
    /// </summary>
    public class MaxSubArrayProblem
    {
        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                int n = nums.Length;
                int currSum = nums[0], maxSum = nums[0];

                for (int i = 1; i < n; ++i)
                {
                    currSum = Math.Max(nums[i], currSum + nums[i]);
                    maxSum = Math.Max(maxSum, currSum);
                }
                return maxSum;
            }
        }
    }
}