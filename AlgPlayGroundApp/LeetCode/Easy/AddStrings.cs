using System;
using System.Collections.Generic;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/add-strings
    /// </summary>
    public class AddStrings
    {
        public class MySolution
        {
            public string AddStrings(string num1, string num2)
            {
                int p1 = num1.Length - 1;
                int p2 = num2.Length - 1;
                int carry = 0;
                List<int> digits = new List<int>();
                while (p1 >= 0 || p2 >= 0)
                {
                    var d1 = GetDigit(num1, p1--);
                    var d2 = GetDigit(num2, p2--);
                    var sum = d1 + d2 + carry;
                    var result = 0;
                    if (sum < 10)
                    {
                        carry = 0;
                        result = sum;
                    }
                    else if (sum == 10)
                    {
                        carry = 1;
                        result = 0;
                    }
                    else
                    {
                        result = sum - 10;
                        carry = 1;
                    }
                    digits.Add(result);

                }

                if(carry > 0)
                    digits.Add(carry);

                var builder = new System.Text.StringBuilder();
                for (int index = digits.Count - 1; index >= 0; index--)
                {
                    builder.Append(digits[index]);
                }

                return builder.ToString();
            }

            private int GetDigit(string num, int index)
            {
                if (index < 0 || index > num.Length)
                    return 0;

                return int.Parse(num.Substring(index,1));
            }
        }
    }
}