﻿using System;

namespace AlgPlayGroundApp.Sorting
{
    /// <summary>
    /// Best-Case:  O(n log n)
    /// Average-Case:  O(n log n)
    /// Worst-Case:  O(n2)
    /// Space Complexity: O(n)
    /// clear explanation at https://www.geeksforgeeks.org/quick-sort/
    /// and c# impl https://exceptionnotfound.net/quick-sort-csharp-the-sorting-algorithm-family-reunion/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSort<T> where T : IComparable<T>
    {
        private void Swap(T[] array, int index1, int index2)
        {
            var tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;
        }

        /// <summary>
        /// start & end are indices in array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start">array index of first element in segment we need to sort its values</param>
        /// <param name="end">array index of last element in segment we need to sort its values</param>
        /// <returns></returns>
        private int Partition(T[] array, int start, int end)
        {
            //select last element as pivot
            var pivot = array[end];
            //boundary is pointer refers to end of left partition
            // initially left partition is empty so if start = 0 then boundary = -1
            var boundary = start - 1;
            for (int i = start; i < end ; i++)
            {
                if (array[i].CompareTo(pivot) <= 0)
                {
                    boundary++;
                    Swap(array,i,boundary);
                }
            }
            //swap to put pivot in its correct place
            Swap(array, boundary+1, end);

            //here (boundary+1) will refer to pivot position & pivot will be in its correct location
            return boundary +1;
        }

        private void Sort(T[] array, int start, int end)
        {
            if (start >= end)
                // if start == end then array contains single element
                // if start > end then array is empty 
                return;

            int partitionPosition = Partition(array, start, end);
            //Sort lift partition
            Sort(array,start,partitionPosition - 1);
            // sort right partition
            Sort(array, partitionPosition +1, end);
        }

        public void Sort(T[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            Sort(array, 0, array.Length -1);
        }
    }
}