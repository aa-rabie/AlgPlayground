using System;
using System.Linq;
using AlgPlayGroundApp.DataStructures;

namespace AlgPlayGroundApp.Helpers
{
    public class ArrayHelper
    {
        public static void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
        /// <summary>
        /// this problem will be solved using maxHeap
        /// Algorithm steps
        /// 1) add all array values to maxHeap
        /// 2) remove (k-1) elements from heap
        /// 3) maxHeap root elm will be the Kth largest value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static T GetKthLargestValue<T>(T[] array, int k) where T : IComparable<T>
        {
            if(array == null)
                throw new ArgumentNullException(nameof(array));
            if(!array.Any())
                throw new ArgumentException("array is empty", nameof(array));
            if(k <= 0 || k > array.Length)
                throw new ArgumentOutOfRangeException(nameof(k));

            var maxHeap = new Heap<T>(array.Length);
            foreach (var item in array)
            {
                maxHeap.Insert(item);
            }

            for (int i = 0; i < k - 1; i++)
            {
                maxHeap.Remove();
            }

            return maxHeap.Max;
        }
    }
}