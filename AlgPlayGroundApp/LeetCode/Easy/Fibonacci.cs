using System.Collections.Generic;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/fibonacci-number/
    /// https://leetcode.com/problems/fibonacci-number/solution/
    /// </summary>
    public class Fibonacci
    {
        public int FibWithMemoization(int n)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            return FibWithMemoization(n, hash);

        }

        private int FibWithMemoization(int n, Dictionary<int, int> hash)
        {
            if (hash.ContainsKey(n))
                return hash[n];

            var result = 0;
            if (n < 2)
                result = n;
            else
            {
                result = FibWithMemoization(n - 1, hash) + FibWithMemoization(n - 2, hash);
            }
            hash.Add(n, result);
            return result;
        }
    }
}