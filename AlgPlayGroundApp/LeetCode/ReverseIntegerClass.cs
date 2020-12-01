using System;

namespace AlgPlayGroundApp.LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-integer/
    /// </summary>
    public class ReverseIntegerClass
    {
        public int LeetSolution(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }

        public static int MySolution(int x)
        {
            if (x == 0)
                return 0;
            var strNum = x.ToString();
            string sign = string.Empty;
            if (strNum[0] == '-')
            {
                sign = "-";
                strNum = strNum.Substring(1);
            }
            var chars = strNum.ToCharArray();
            strNum = null;
            int start = 0;
            int end = chars.Length - 1;
            while (start < end)
            {
                var tmp = chars[start];
                chars[start] = chars[end];
                chars[end] = tmp;
                end--;
                start++;
            }
            string reversedNumber = $"{sign}{new string(chars)}";
            chars = null;
            try
            {
                var result = int.Parse(reversedNumber);
                return result;
            }
            catch (OverflowException)
            {
                return 0;
            }
            finally
            {
                reversedNumber = null;
            }
        }
    }
}