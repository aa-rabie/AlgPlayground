using System;

namespace AlgPlayGroundApp.LeetCode
{
    /// <summary>
    /// Problem at https://leetcode.com/explore/learn/card/binary-search/125/template-i/952/
    /// Solution at https://leetcode.com/problems/search-in-rotated-sorted-array/editorial/
    /// Solution is done using Binary search
    /// </summary>
    /*
     *  There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) 
    such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed).
    For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, 
    return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.
     *
     */
    public class SearchInRotatedSortedArrayProblem
    {
        public int Search(int[] nums, int target)
        {
            int n = nums.Length;

            if (n == 1)
                return nums[0] == target ? 0 : -1;

            //step #1 find index of smallest element in array 
            int rotate_index = find_rotate_index(nums, 0, n - 1);

            // if target is the smallest element
            if (nums[rotate_index] == target)
                return rotate_index;
            // if array is not rotated, search in the entire array
            if (rotate_index == 0)
                return Search(nums, target, 0, n - 1);

            if (target < nums[0])
                // search in the right side
                return Search(nums, target, rotate_index, n - 1);

            // search in the left side
            return Search(nums, target, 0, rotate_index);
        }

        private int find_rotate_index(int[] nums, int left, int right)
        {
            if (nums[left] < nums[right])
                return 0;

            while (left <= right)
            {
                int pivot = (left + right) / 2;
                if (nums[pivot] > nums[pivot + 1])
                    return pivot + 1;
                else
                {
                    if (nums[pivot] < nums[left])
                        right = pivot - 1;
                    else
                        left = pivot + 1;
                }
            }
            return 0;
        }
        private int Search(int[] nums, int target, int left, int right)
        {
            /*
            Binary search
            */
            while (left <= right)
            {
                int pivot = (left + right) / 2;
                if (nums[pivot] == target)
                    return pivot;
                else
                {
                    if (target < nums[pivot])
                        right = pivot - 1;
                    else
                        left = pivot + 1;
                }
            }
            return -1;
        }

        public void Test()
        {
            var nums = new int[]{4, 5, 6, 7, 0, 1, 2};
            var result = Search(nums, 0);
            Console.WriteLine($"{result} should equal {4}");
        }
    }
}