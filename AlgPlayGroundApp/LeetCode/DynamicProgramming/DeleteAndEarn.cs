using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPlayGroundApp.LeetCode.DynamicProgramming
{
    // https://leetcode.com/problems/delete-and-earn/description/

    /*
     Algorithm
        1. Declare a hash table points that will map elements to the number of points that we can gain from taking each element. 
            Also, declare a hash map cache that we will use to memoize our recursive function.
        2. Loop through nums once to populate points to find maxNumber, which is the largest element in nums.
        3. Initialize a function maxPoints, where maxPoints(num) will 
            return the maximum amount of points we can gain if we only consider numbers from 0 to num.
        4. In maxPoints, first check for the base cases. If num == 0, return 0. If num == 1, return points[1]. Otherwise, 
            check if num is already in cache. If it is, just return cache[num].
        5. Otherwise, apply the recurrence relation. Find the answer for num with max(maxPoints(num - 1), maxPoints(num - 2) + points[num]). 
            Store this answer in cache, and then return it.
        6. Return maxPoints(maxNumber).

     */

    internal class DeleteAndEarnProblem
    {
        Dictionary<int, int> points = null;
        Dictionary<int, int> cache = null;

        private int MaxPoints(int x)
        {
            if (x == 0)
                return 0;
            if (x == 1)
            {
                points.TryGetValue(1, out var val);
                return val;
            }

            if (cache.ContainsKey(x))
                return cache[x];

            points.TryGetValue(x, out var gain);

            var takeXGain = MaxPoints(x - 2) + gain;
            var notTakingXGain = MaxPoints(x - 1);
            cache.Add(x, Math.Max(takeXGain, notTakingXGain));

            return cache[x];
        }

        public int DeleteAndEarn(int[] nums)
        {

            points = new Dictionary<int, int>(nums.Length);
            cache = new Dictionary<int, int>(nums.Length);

            var maxNumber = 0;
            foreach (var n in nums)
            {
                if (n > maxNumber)
                {
                    maxNumber = n;
                }

                if (points.ContainsKey(n))
                {
                    points[n] += n;
                }
                else
                {
                    points[n] = n;
                }
            }

            return MaxPoints(maxNumber);
        }

    }
}
