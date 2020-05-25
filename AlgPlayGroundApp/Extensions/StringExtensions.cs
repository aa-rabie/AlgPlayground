using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgPlayGroundApp.Extensions
{
    public static class StringExtensions
    {
        public static string ReverseUsingStack(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            Stack<char> charStack = new Stack<char>();
            foreach (var ch in input)
            {
                charStack.Push(ch);
            }

            StringBuilder reversed = new StringBuilder();
            while (charStack.Count > 0)
                reversed.Append(charStack.Pop());

            return reversed.ToString();
        }
    }
}