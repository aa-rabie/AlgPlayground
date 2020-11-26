using System.Collections.Generic;

namespace AlgPlayGroundApp.LeetCode
{
    public class RomanNumberToIntConverter
    {
        public class MySolution
        {
            /// <summary>
            /// https://leetcode.com/problems/roman-to-integer/
            /// </summary>
            /// <param name="s">Roman-Number as string</param>
            /// <returns>number as integer</returns>
            public int RomanToInt(string s)
            {
                if (string.IsNullOrEmpty(s))
                    return 0;

                s = s.Trim();
                var result = 0;
                var len = s.Length;
                var bypassNextChar = false;
                for (int i = 0; i < len; i++)
                {
                    if (bypassNextChar)
                    {
                        bypassNextChar = false;
                        continue;
                    }

                    if (i < len - 1)
                    {
                        if (IsSpecialRomanDigit(s[i], s[i + 1]))
                        {
                            bypassNextChar = true;
                            result += ToIntSpecial(s[i], s[i + 1]);
                        }
                        else
                        {
                            result += ToInt(s[i]);
                        }
                    }
                    else
                    {
                        result += ToInt(s[i]);
                    }
                }

                return result;
            }

            private bool IsSpecialRomanDigit(char left, char right)
            {
                return
                    (left == 'I' && right == 'V') ||
                    (left == 'I' && right == 'X') ||
                    (left == 'X' && right == 'L') ||
                    (left == 'X' && right == 'C') ||
                    (left == 'C' && right == 'D') ||
                    (left == 'C' && right == 'M');
            }

            private int ToIntSpecial(char left, char right)
            {
                var str = $"{left}{right}";
                if (str == "IV")
                    return 4;
                if (str == "IX")
                    return 9;
                if (str == "XL")
                    return 40;
                if (str == "XC")
                    return 90;
                if (str == "CD")
                    return 400;
                if (str == "CM")
                    return 900;

                return 0;
            }

            private int ToInt(char ch)
            {
                switch (ch)
                {
                    case 'I':
                        return 1;
                    case 'V':
                        return 5;
                    case 'X':
                        return 10;
                    case 'L':
                        return 50;
                    case 'C':
                        return 100;
                    case 'D':
                        return 500;
                    case 'M':
                        return 1000;
                    default:
                        return 0;
                }
            }
        }

        class LeetSolution
        {


            private static readonly Dictionary<string, int> Values = new Dictionary<string, int>()
            {
                {"M", 1000},
                {"D", 500},
                {"C", 100},
                {"L", 50},
                {"X", 10},
                {"V", 5},
                {"I", 1}
            };

            public int RomanToInt(string s)
            {

                int sum = 0;
                int i = 0;
                while (i < s.Length)
                {
                    string currentSymbol = s.Substring(i, i + 1);
                    int currentValue = Values[currentSymbol];
                    int nextValue = 0;
                    if (i + 1 < s.Length)
                    {
                        string nextSymbol = s.Substring(i + 1, i + 2);
                        nextValue = Values[nextSymbol];
                    }

                    if (currentValue < nextValue)
                    {
                        sum += (nextValue - currentValue);
                        i += 2;
                    }
                    else
                    {
                        sum += currentValue;
                        i += 1;
                    }

                }

                return sum;
            }
        }
    }
}