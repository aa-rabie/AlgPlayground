using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPlayGroundApp.LeetCode.DynamicProgramming
{
    internal class HouseRobber
    {
        // https://leetcode.com/problems/house-robber/
        public int Rob(int[] nums)
        {
            if (nums.Length == 1) 
                return nums[0];

            var dp = new int[nums.Length];

            //setting base case
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int index = 2; index < nums.Length; index++)
            {
                // Recurrence relation
                dp[index] = Math.Max(dp[index - 1], dp[index - 2] + nums[index]);
            }

            return dp[dp.Length - 1];
        }
    }
}
