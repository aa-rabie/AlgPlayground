using System;

namespace AlgPlayGroundApp.LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/sqrtx/editorial/
    /// Given a non-negative integer x, return the square root of x rounded down to the nearest integer.
    /// The returned integer should be non-negative as well.
    /// </summary>
    public class MySqrtCalculator
    {
        /// <summary>
        /// method 1 in link
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int UsingLog(int x)
        {
            if (x < 2) return x;

            int left = (int)Math.Pow(Math.E, 0.5 * Math.Log(x));
            int right = left + 1;
            return (long)right * right > x ? left : right;
        }

        /// <summary>
        /// method 2 in link
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int UsingBinarySearch(int x)
        {
            if (x < 2) return x;

            long num;
            int pivot, left = 2, right = x / 2;
            while (left <= right)
            {
                pivot = left + (right - left) / 2;
                num = (long)pivot * pivot;
                if (num > x) right = pivot - 1;
                else if (num < x) left = pivot + 1;
                else return pivot;
            }

            return right;
        }

        public static void Test()
        {
            Console.WriteLine(new MySqrtCalculator().UsingBinarySearch(8));
            Console.WriteLine(new MySqrtCalculator().UsingLog(8));
        }
    }
}