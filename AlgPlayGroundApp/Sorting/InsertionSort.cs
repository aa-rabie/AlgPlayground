using System;

namespace AlgPlayGroundApp.Sorting
{
    /// <summary>
    /// Best Time : O(N) - Linear
    ///  worst Time:  O(N pow 2) - quadratic - because there will be N passes & N-1 comparisons
    /// video #7 & #8 in Mosh Course Part III
    /// </summary>
    public class InsertionSort<T> where T : IComparable<T>
    {
       
        public void Sort(T[] array)
        {
            if(array == null || array.Length == 0)
                return;
            for (int i = 1; i < array.Length; i++)
            {
                var current = array[i];
                var j = i - 1;
                //check elements in sub-array before index i
                // if any of them is greater than value at index i then shift elements in syb-array to right
                while (j >= 0 && array[j].CompareTo(current) > 0)
                {
                    // shift values to right
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = current;
            }

        }
    }
}