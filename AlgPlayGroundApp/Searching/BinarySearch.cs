using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgPlayGroundApp.Searching
{
    /// <summary>
    /// as a prerequisite - array should be sorted
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="target">value that we need to find</param>
        /// <param name="startIndex">array index of first element in segment we need to search in its values</param>
        /// <param name="endIndex">array index of last element in segment we need to search in its values</param>
        /// <returns>index of target element if found otherwise -1</returns>
        internal int Search(IList<int> data, int target, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
                return -1; // The segment that we should search in it => is empty

            var middle = Convert.ToInt32((startIndex + endIndex) / 2);

            if (target == data[middle])
                return middle;

            if (target < data[middle])
                //search in left part
                return Search(data, target, startIndex, middle - 1);

            //search in right part
            return Search(data, target, middle + 1, endIndex);
        }

        public int Search(IList<int> data, int target)
        {
            return Search(data, target, 0, data.Count - 1);
        }
    }
}