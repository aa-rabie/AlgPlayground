using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgPlayGroundApp.Helpers
{
    public static class StringReverse
    {
        public static string ReverseUsingStack(string input)
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

        public static char[] ReverseInPlace(char[] input)
        {
            if (input == null || input.Length == 0)
                return input;

            Swap(0, input.Length-1, input);

            return input;
        }

        private static void Swap(int left, int right, char[] input)
        {
            if(left >= right)
                return;
            char tmp = input[left];
            input[left] = input[right];
            input[right] = tmp;

            Swap(left +1 , right -1 , input);

        }
    }
}