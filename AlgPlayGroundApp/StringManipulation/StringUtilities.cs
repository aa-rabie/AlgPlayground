using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!words.Any())
                return string.Empty;

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

        public static string RemoveDuplicates(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            HashSet<char> seenChars = new HashSet<char>();
            foreach (var ch in str)
            {
                if (!seenChars.Contains(ch))
                {
                    seenChars.Add(ch);
                    builder.Append(ch);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gets the most occuring Char
        /// Assuming the input string has only ASCII characters
        /// </summary>
        /// <param name="input">string that we will search within</param>
        /// <returns>the most occuring character</returns>
        public static char GetMaxOccuringChar(string input)
        {
            if(string.IsNullOrEmpty(input))
                throw new ArgumentException("input string is null or empty", nameof(input));
            const int asciiSize = 256;
            var frequencies = new int[asciiSize];
            //count the characters frequencies
            foreach (var ch in input)
                frequencies[ch]++;

            var max = 0;
            char result = default(char);
            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] > max)
                {
                    max = frequencies[i];
                    result = (char) i;
                }
            }

            return result;
        }

        public static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            str = str.Trim();

            if (string.IsNullOrEmpty(str))
                return string.Empty;

            var words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if(!words.Any())
                return string.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0,1).ToUpper() + 
                           (words[i].Substring(1) ?? string.Empty).ToLower();
            }

            return string.Join(' ', words);
        }
    }
}