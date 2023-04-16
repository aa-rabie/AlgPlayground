using AlgPlayGroundApp.DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using static AlgPlayGroundApp.DataStructures.HashTable;

namespace AlgPlayGroundApp.LeetCode.Arrays
{
    /// <summary>
    /// https://leetcode.com/explore/learn/card/array-and-string/205/array-two-pointer-technique/1153/
    /// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order,
    /// find two numbers such that they add up to a specific target number.
    /// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    /// Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.
    /// The tests are generated such that there is exactly one solution. You may not use the same element twice.

    ///Your solution must use only constant extra space.
    ///
    /// Example 1:
    /// Input: numbers = [2,7,11,15], target = 9
    /// Output: [1,2]
    /// Example 2:
    /// Input: numbers = [2,3,4], target = 6
    /// Output: [1,3]
    /// 
    /// Solution => https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/editorial/
    /// We use two indices, initially pointing to the first and the last element,
    /// respectively. Compare the sum of these two elements with target.
    /// If the sum is equal to target, we found the exactly only solution.
    /// If it is less than target, we increase the smaller index by one.
    /// If it is greater than target, we decrease the larger index by one.
    /// Move the indices and repeat the comparison until the solution is found.

    /// Let[..., a, b, c, ..., d, e, f, ...]
    /// be the input array that is sorted in ascending order and
    /// let the elements b and e be the exactly only solution.
    /// Because we are moving the smaller index from left to right,
    /// and the larger index from right to left, at some point,
    /// one of the indices must reach either bbb or eee. Without loss of generality,
    /// suppose the smaller index reaches bbb first.At this time,
    /// the sum of these two elements must be greater than target.
    /// Based on our algorithm, we will keep moving the larger index to the left until we reach the solution.
    /// </summary>
    public class TwoSumII
    {
        public static int[] Run(int[] numbers, int target)
        {
            if (numbers == null)
                return new int[] { };

            int i = 0;
            int j = numbers.Length - 1;
            while (i < j)
            {
                var sum = numbers[i] + numbers[j];
                if (sum == target)
                {
                    return new int[] { i + 1, j + 1 };
                }
                else if (sum < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return new int[] { };
        }
    }
}