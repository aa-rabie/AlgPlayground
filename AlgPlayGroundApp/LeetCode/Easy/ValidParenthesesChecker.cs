namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/valid-parentheses/
    /// there is another solution to this problem (from Mosh Course) defined in ExpressionChecker class
    /// </summary>
    public class ValidParenthesesChecker
    {
        public class MySolution
        {
            public bool IsValid(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return true;
                }

                var st = new System.Collections.Generic.Stack<char>();
                var openP = new System.Collections.Generic.List<char>();
                var closedP = new System.Collections.Generic.List<char>();
                openP.Add('(');
                openP.Add('{');
                openP.Add('[');
                closedP.Add(')');
                closedP.Add('}');
                closedP.Add(']');
               
                foreach (var ch in s)
                {
                    if (openP.IndexOf(ch) == -1 && closedP.IndexOf(ch) == -1)
                    {
                        return false;
                    }

                    if (openP.IndexOf(ch) > -1)
                    {
                        st.Push(ch);
                    }
                    else
                    {
                        if (st.Count == 0)
                            return false;

                        var openCh = st.Pop();
                        if (openP.IndexOf(openCh) != closedP.IndexOf(ch))
                            return false;
                    }
                }

                return st.Count == 0;
            }
        }
    }
}