using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.Searching
{
    /// <summary>
    /// array should be sorted
    /// Exponential Search uses BinarySearch
    /// more info at video #28 in Mosh Data Structures III 
    /// </summary>
    public class ExponentialSearch
    {
        public int? Search(IList<int> data, int target)
        {
            if (data == null || !data.Any())
                return null;

            int bound = 1;
            while (bound < data.Count && data[bound] < target)
            {
                bound *= 2;
            }

            var left = bound / 2;
            var right = Math.Min(bound, data.Count - 1);

            return new BinarySearch().Search(data, target, left, right);
        }
    }
}