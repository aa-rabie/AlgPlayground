namespace AlgPlayGroundApp.LeetCode
{
    public class AddBinaryProblem
    {
        /// <summary>
        /// https://leetcode.com/explore/learn/card/array-and-string/203/introduction-to-string/1160/
        /// Given two binary strings a and b, return their sum as a binary string.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            var i = a.Length - 1;
            var j = b.Length - 1;
            var hasCarry = false;
            var result = new System.Text.StringBuilder();
            while (i >= 0 || j >= 0)
            {

                if (i >= 0 && j >= 0)
                {
                    hasCarry = Add(a[i], b[j], hasCarry, out var c);
                    result.Insert(0, c);
                }
                else if (i >= 0)
                {
                    if (hasCarry)
                    {
                        hasCarry = Add(a[i], '0', true, out var c);
                        result.Insert(0, c);
                    }
                    else
                    {
                        result.Insert(0, a[i]);
                    }
                }
                else if (j >= 0)
                {
                    if (hasCarry)
                    {
                        hasCarry = Add(b[j],  '0' , true, out var c);
                        result.Insert(0, c);
                    }
                    else
                    {
                        result.Insert(0, b[j]);
                    }
                }

                i -= 1;
                j -= 1;

            }

            if (hasCarry)
            {
                result.Insert(0, '1');
            }
            return result.ToString();
        }

        private bool Add(char a, char b, bool hasCarry, out char c)
        {
            int first = a == '0' ? 0 : 1;
            int second = b == '0' ? 0 : 1;
            var result = first + second;

            if (hasCarry)
            {
                result += 1;
            }

            if (result == 3)
            {
                c = '1';
                return true;
            }
            else if (result == 2)
            {
                c = '0';
                return true;
            }

            c = result == 1 ? '1' : '0';
            return false;

        }
    }
}