using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AlgPlayGroundApp.LeetCode
{
    // problem : https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/674/
    public class IntersectionOfTwoArraysII
    {
        /*
        Algorithm

        If nums1 is larger than nums2, swap the arrays.

        For each element in nums1:

            Add it to the hash map m.
                Increment the count if the element is already there.

        Initialize the insertion pointer (k) with zero.

        Iterate along nums2:

            If the current number is in the hash map and count is positive:

                Copy the number into nums1[k], and increment k.

                Decrement the count in the hash map.

        Return first k elements of nums1.
         */
        public int[] GetIntersectionsUsingDictionary(int[] nums1, int[] nums2)
        {
            // it is better to use hashTable with smaller array; to use smaller memory
            int[] smaller = nums1.Length <= nums2.Length ? nums1 : nums2;
            int[] larger = nums1.Length > nums2.Length ? nums1 : nums2;

            Dictionary<int, int> counter = new Dictionary<int, int>(smaller.Length);
            foreach (var i in smaller)
            {
                if (counter.ContainsKey(i))
                {
                    counter[i] += 1;
                }
                else
                {
                    counter.Add(i, 1);
                }
            }

            int index = 0;
            foreach (var j in larger)
            {
                if (counter.ContainsKey(j) && counter[j] > 0)
                {
                    counter[j] -= 1;
                    smaller[index++] = j;
                }
            }

            var result = new int[index];
            Array.Copy(smaller, 0, result, 0, index);
            return result;
        }

        public int[] GetIntersectionUsingSorting(int[] nums1, int[] nums2)
        {
            /*
Algorithm

    Sort nums1 and nums2.

    Initialize i, j and k with zero.

    Move indices i along nums1, and j through nums2:

        Increment i if nums1[i] is smaller.

        Increment j if nums2[j] is smaller.

        If numbers are the same, copy the number into nums1[k], and increment i, j and k.

    Return first k elements of nums1.
             */
            Array.Sort(nums1);
            Array.Sort(nums2);
            int i = 0, j = 0, k = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    ++i;
                }
                else if (nums1[i] > nums2[j])
                {
                    ++j;
                }
                else
                {
                    nums1[k++] = nums1[i++];
                    ++j;
                }
            }

            var result = new int[k];
            Array.Copy(nums1, 0, result, 0, k);
            return result;
        }
    }
}