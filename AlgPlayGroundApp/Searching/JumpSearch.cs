using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.Searching
{
    /// <summary>
    /// Time Complexity : O(Sqrt of N)
    /// check video 26 & 27 from Mosh Data Structures III course
    /// its performance is better than linear search but worse than binary search
    /// Prerequisite : I think array should be sorted
    /// </summary>
    public class JumpSearch<T> where T : IComparable<T>
    {

        public int Search(IList<T> data, T target)
        {
            if (data is null || !data.Any())
                return -1;

            var blockSize = (int) Math.Sqrt(data.Count);
            int start = 0;
            int next = blockSize;

            while (start < data.Count && data[next - 1].CompareTo(target) < 0)
            {
                // target does not exist in this block 
                // so jump to next block
                start = next;
                next += blockSize;
                if (next > data.Count)
                    next = data.Count;
            }
            //here we identified block boundaries so we do linear search within this block
            for (int i = start; i < next; i++)
            {
                if (data[i].CompareTo(target) == 0)
                    return i;

            }

            return -1;
        }
    }
}