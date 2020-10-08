using System.Collections.Generic;

namespace AlgPlayGroundApp.GenericQuestions
{
    /// <summary>
    /// solution found in https://www.geeksforgeeks.org/find-if-there-is-a-subarray-with-0-sum/
    /// </summary>
    public class ArrayHasZeroSumSubSequenceOrNot
    {
        /*
         Sample Input
         2 8 -9 1
         2 1 3 4 -9 6 8 9 -100000 123132131
         -5 8 0 4
         */
        // Returns true if arr[] has  
        // a subarray with sero sum  
        public bool SubArrayExists(int[] arr)
        {
            // Creates an empty HashSet hM  
            HashSet<int> hs = new HashSet<int>();
            // Initialize sum of elements  
            int sum = 0;

            // Traverse through the given array  
            for (int i = 0; i < arr.Length; i++)
            {
                // Add current element to sum  
                sum += arr[i];

                // Return true in following cases  
                // a) Current element is 0  
                // b) sum of elements from 0 to i is 0  
                // c) sum is already present in hash set  
                if (arr[i] == 0 || sum == 0 || hs.Contains(sum))
                    return true;

                // Add sum to hash set  
                hs.Add(sum);
            }

            // We reach here only when there is  
            // no subarray with 0 sum  
            return false;
        }
    }
}