using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// Problem link @ https://leetcode.com/problems/verifying-an-alien-dictionary/
    /// </summary>
    public class VerifyingAlienDict
    {
        public bool IsAlienSorted(string[] words, string order)
        {
            if(string.IsNullOrEmpty(order))
                throw new ArgumentException(nameof(order));

            if (words == null || !words.Any())
                return true;

            Dictionary<char,int> dict = new Dictionary<char, int>();
            //adding blank character
            var blank = ' ';
            dict.Add(blank, -1);
            var index = 0;
            foreach (var ch in order)
            {
                dict.Add(ch,index++);
            }

            for (int i = 0; i < words.Length-1; i++)
            {
                if (!IsWordsSorted(words[i], words[i + 1]))
                    return false;
            }

            return true;

            bool IsWordsSorted(string w1, string w2)
            {
                if (w2.Length < w1.Length)
                    w2 = w2.PadRight(w1.Length, blank);

                for (int i = 0; i < w1.Length; i++)
                {
                    if (dict[w1[i]] < dict[w2[i]])
                        return true;
                    else
                    {
                        if ((dict[w1[i]] > dict[w2[i]]))
                            return false;
                    }
                }

                if (w1.Length < w2.Length)
                {
                    // if same character but w1 is less in length then w1 should be ordered before w2 & we should return true
                    return true;
                }
                //both words have same characters & length
                return true;
            }
        }
    }
}