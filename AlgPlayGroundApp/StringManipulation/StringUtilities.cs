using System;
using System.Text;

namespace AlgPlayGroundApp.StringManipulation
{
    public class StringUtilities
    {
        public static int CountVowels(string input)
        {
            var count = 0;
            if (string.IsNullOrEmpty(input))
                return count;

            input = input.ToLowerInvariant();

            var vowels = "aeoui";
            foreach (var ch in input)
            {
                if (vowels.Contains(ch))
                    count++;
            }
            return count;
        }

        public static string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            StringBuilder builder = new StringBuilder();

            for (var i = str.Length -1; i >= 0 ; i--)
            {
                builder.Append(str[i]);
            }

            return builder.ToString();
        }

        public static string ReverseWords(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            var words = str.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();

            for (var i = words.Length - 1; i >= 0; i--)
            {
                builder.Append(words[i]);
                builder.Append(' ');
            }

            // remove extra white space in the end
            return builder.ToString().Trim();
        }

        /// <summary>
        /// return true if str2 is rotation of str1
        /// for example "BCDA" is rotation of "ABCD"
        /// more information at video #34 from Mosh data structures course III
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool AreRotations(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return false;

            return str1.Length == str2.Length
                   && (str1 + str1).Contains(str2);
        }
    }
}