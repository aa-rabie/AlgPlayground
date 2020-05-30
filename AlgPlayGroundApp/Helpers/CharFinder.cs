using System;
using System.Collections.Generic;

namespace AlgPlayGroundApp.Helpers
{
    class CharFinder
    {
        public char? FindFirstNonRepeating(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;

            // building char counter map; we need to know how many times a char is repeated
            Dictionary<char,int> charCount = new Dictionary<char, int>();
            foreach (var ch in input)
            {
                if (charCount.ContainsKey(ch))
                {
                    charCount[ch] = charCount[ch] + 1;
                }
                else
                {
                    charCount.Add(ch,1);
                }
            }
            //use hashtable to identify first non-repeating char
            foreach (var ch in input)
            {
                if (charCount[ch] == 1)
                {
                    return ch;
                }
            }

            return null;
        }
    }
}
