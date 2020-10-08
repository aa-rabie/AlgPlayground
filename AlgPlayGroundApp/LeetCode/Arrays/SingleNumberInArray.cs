using System.Collections.Generic;

namespace AlgPlayGroundApp.LeetCode.Arrays
{
    /*
     * problem described at https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/ 
     * Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

        Follow up: Could you implement a solution with a linear runtime complexity and without using extra memory?
     */
    public class SingleNumberInArray
    {
        public int FindSingleNumberUsingHashTable(int[] nums)
        {
            Dictionary<int,int> numCounter = new Dictionary<int, int>(nums.Length);
            foreach (var i in nums)
            {
                if (numCounter.ContainsKey(i))
                {
                    numCounter[i] += 1;
                }
                else
                {
                    numCounter[i] = 1;
                }
            }

            foreach (var pair in numCounter)
            {
                if (pair.Value == 1)
                    return pair.Key;
            }

            return 0;
        }

        public int FindSingleNumberUsingXor(int[] nums)
        {
            /*
             
            If we take XOR of zero and some bit, it will return that bit
               a XOR 0 = a
            If we take XOR of two same bits, it will return 0
               a XOR a = 0
            
            (a XOR b XOR a) = (a XOR a) XOR b = (0 XOR b) = b

                So we can XOR all bits together to find the unique number.
             */

            int a = 0;
            foreach (var i in nums)
            {
                a ^= i;
            }
            return a;
        }
    }
}