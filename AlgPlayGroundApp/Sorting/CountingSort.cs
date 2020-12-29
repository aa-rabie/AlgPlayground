using System;

namespace AlgPlayGroundApp.Sorting
{
    /// <summary>
    /// Time complexity : O(N)
    /// Space Complexity : O(K) where K is the max value in input array
    /// 
    /// we should use this algorithm if
    /// 1) all values are non-negative numbers
    ///  2) it is no problem to allocate extra space
    /// 3) Most value in the range are present
    ///
    /// more info at video #14 , 15 in Mosh data structure course III
    /// </summary>
    public class CountingSort
    {
        public void Sort(int[] arr, int maxValue)
        {
            if(maxValue < 0)
                throw  new ArgumentOutOfRangeException(nameof(maxValue), "value should be non-negative");
            if (arr == null || arr.Length == 0)
                return;

            int[] counts = new int[maxValue +1];

            // we iterate over input array 
            // count how many times  each value appears in array 
            foreach (var t in arr)
            {
                counts[t]++;
            }

            //iterate over counts array & update values in input array (in a sorted way)
            var k = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                for (int j = 0; j < counts[i]; j++)
                {
                    arr[k++] = i;
                }
            }
        }
    }
}