﻿using System;
using System.Globalization;

namespace AlgPlayGroundApp.Sorting
{
    /// <summary>
    ///  Time:  O(N pow 2) - quadratic - because there will be N passes & N-1 comparisons
    /// video #5 & #6 in Mosh Course Part III
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectionSort<T>  where T : IComparable<T>
    {
        /// <summary>
        /// idea : iterate over array & try to find the min-element-Index and then put that min-value in correct location
        /// after first iteration => min elm will be at index zero
        /// then in second iteration we search for min value in "rest of array starting of index 1" because array[0] is already sorted in iteration #1
        /// we repeat the process till we iterate over all elements in array  
        /// </summary>
        /// <param name="arr"></param>
        public void Sort(T[] arr)
        {
            if(arr == null || arr.Length == 0)
                return;
            for (int i = 0; i < arr.Length; i++)
            {
                var minIndex = GetMinIndex(arr, i);
                Swap(arr, minIndex , i);
            }
        }

        private int GetMinIndex(T[] arr, int i)
        {
            // assume that minIndex is i then we compare value at minIndex with Rest of Array
            var minIndex = i;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j].CompareTo(arr[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            return minIndex;
        }

        private void Swap(T[] array, int index1, int index2)
        {
            var tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;
        }
    }
}