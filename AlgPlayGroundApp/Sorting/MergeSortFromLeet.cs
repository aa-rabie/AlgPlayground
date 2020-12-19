using System;

namespace AlgPlayGroundApp.Sorting
{
    public class MergeSortFromLeet
    {
        public class Solution
        {

            public int[] MergeSort(int[] input)
            {
                if (input.Length <= 1)
                {
                    return input;
                }
                int pivot = input.Length / 2;
                int[] leftList = new int[pivot];
                int[] rightList = new int[input.Length - pivot];

                Array.Copy(input, 0, leftList, 0, pivot);
                Array.Copy(input, pivot, rightList, 0, input.Length - pivot);

                leftList = MergeSort(leftList);
                rightList = MergeSort(rightList);

                return Merge(leftList, rightList);
            }

            private int[] Merge(int[] leftList, int[] rightList)
            {
                int[] ret = new int[leftList.Length + rightList.Length];
                int leftCursor = 0, rightCursor = 0, retCursor = 0;

                while (leftCursor < leftList.Length &&
                       rightCursor < rightList.Length)
                {
                    if (leftList[leftCursor] < rightList[rightCursor])
                    {
                        ret[retCursor++] = leftList[leftCursor++];
                    }
                    else
                    {
                        ret[retCursor++] = rightList[rightCursor++];
                    }
                }
                // append what is remain the above lists
                while (leftCursor < leftList.Length)
                {
                    ret[retCursor++] = leftList[leftCursor++];
                }
                while (rightCursor < rightList.Length)
                {
                    ret[retCursor++] = rightList[rightCursor++];
                }
                return ret;
            }
        }
    }
}