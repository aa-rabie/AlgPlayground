using System;

namespace AlgPlayGroundApp.Sorting
{
    /// <summary>
    /// Best Time : O(N) - Linear
    ///  worst Time:  O(N pow 2) - quadratic - because there will be N passes & N-1 comparisons
    /// video #3 & #4 in Mosh Course Part III
    /// </summary>
    public class BubbleSort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Idea : we iterate over all elements in array and compare value at index j with value at index j-1
        /// && swap both values only if array[j] is "smaller" than array[j-1]
        /// </summary>
        /// <param name="array"></param>
        public void Sort(T[] array)
        {
            if(array == null || array.Length == 0)
                return;
            for (int i = 0; i < array.Length; i++)
            {
                bool isSorted = true;
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j] .CompareTo(array[j - 1]) < 0)
                    {
                        Swap(array, j, j - 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                    return;
            }

        }

        private void Swap(T[] array, int index1, int index2)
        {
            var tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;
        }
    }
}