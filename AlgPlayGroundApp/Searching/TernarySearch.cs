using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgPlayGroundApp.Searching
{
    /// <summary>
    /// as a prerequisite - array should be sorted
    /// Time complexity O(log3N) - 
    /// Binary Search is faster that ternarySearch
    /// more info at video #24 in Mosh data structure course III
    /// </summary>
    public class TernarySearch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="target">value that we need to find</param>
        /// <param name="left">array index of first element in segment we need to search in its values</param>
        /// <param name="right">array index of last element in segment we need to search in its values</param>
        /// <returns>index of target element if found otherwise -1</returns>
        private int Search(IList<int> data, int target, int left, int right)
        {
            if (right < left)
                return -1; // The segment that we should search in it => is empty

            var partitionSize = Convert.ToInt32((right - left) / 3);
            var mid1 = left + partitionSize;
            var mid2 = right - partitionSize;

            if (target == data[mid1])
                return mid1;

            if (target == data[mid2])
                return mid2;

            if (target < data[mid1])
                //search in left part
                return Search(data, target, left, mid1 - 1);

            if (target > data[mid2])
                //search in right part
                return Search(data, target, mid2 + 1, right);

            //search in middle part
            return Search(data, target, mid1 + 1, mid2 -1);
        }

        public int Search(IList<int> data, int target)
        {
            if (data == null || data.Count == 0)
                return -1; // The segment that we should search in it => is empty

            return Search(data, target, 0, data.Count - 1);
        }
    }
}