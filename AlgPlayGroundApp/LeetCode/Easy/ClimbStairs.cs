namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/climbing-stairs/
    /// https://leetcode.com/problems/climbing-stairs/solution/
    /// </summary>
    public class ClimbStairsProblemSolver
    {
        /// <summary>
        /// You are climbing a staircase. It takes n steps to reach the top.
        /// Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int climbStairs(int n)
        {
            var memo = new int[n + 1];
            return climb_Stairs(0, n, memo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">current step</param>
        /// <param name="n">destination step</param>
        /// <param name="memo">used for memoization</param>
        /// <returns></returns>
        public int climb_Stairs(int i, int n, int[] memo)
        {
            if (i > n)
            {
                return 0;
            }
            if (i == n)
            {
                return 1;
            }
            if (memo[i] > 0)
            {
                return memo[i];
            }
            memo[i] = climb_Stairs(i + 1, n, memo) + climb_Stairs(i + 2, n, memo);
            return memo[i];
        }
    }
}