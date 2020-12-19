namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/powx-n/
    /// https://leetcode.com/problems/powx-n/solution/
    /// </summary>
    public class MyPowCalculator
    {
        /*
         Constraints:

            -100.0 < x < 100.0
            -231 <= n <= 231-1
            -104 <= xn <= 104

         */

        public class Solution
        {
            public double MyPow(double x, int n)
            {
                long N = n;
                if (N < 0)
                {
                    x = 1 / x;
                    N = -N;
                }
                double ans = 1;
                for (long i = 0; i < N; i++)
                    ans = ans * x;
                return ans;
            }
        }
    }
}