using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPlayGroundApp.LeetCode.DynamicProgramming
{
   //  https://leetcode.com/problems/min-cost-climbing-stairs/description/
    internal class MinCostClimbingStairsProblem
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            var minCost = new int[cost.Length + 1];

            for (int i = 2; i <= cost.Length; i++)
            {
                minCost[i] = Math.Min(minCost[i - 1] + cost[i - 1]
                , minCost[i - 2] + cost[i - 2]);
            }

            return minCost[cost.Length];
        }
    }
}
