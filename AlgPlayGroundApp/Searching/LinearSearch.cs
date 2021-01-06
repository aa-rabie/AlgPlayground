using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.Searching
{
    /// <summary>
    /// Best Time : O(1) if the item (we search for) exist at index 0
    /// Worst Time : O(N)
    /// </summary>
    public class LinearSearch<T> where T : IEquatable<T>
    {

        public int Search(IList<T> data, T target)
        {
            if (data is null || !data.Any())
                return -1;

            for(var index = 0; index < data.Count;index++)
            {
                var item = data[index];
                if (item.Equals(target))
                    return index;

            }

            return -1;
        }
    }
}