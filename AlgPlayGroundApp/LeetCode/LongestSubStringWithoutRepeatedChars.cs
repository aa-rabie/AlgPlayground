using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlgPlayGroundApp.LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters
    /// </summary>
    public class LongestSubStringWithoutRepeatedChars
    {
        public void Test()
        {
            string s = "abcabcbb";
            Console.WriteLine($"executing {nameof(LengthOfLongestSubstring)} - {LengthOfLongestSubstring(s)} is result of input {s}");
        }


        /*
         *
         * Algorithm

The naive approach is very straightforward. But it is too slow. So how can we optimize it?

In the naive approaches, we repeatedly check a substring to see if it has duplicate character. But it is unnecessary. If a substring s_{ij}s 
ij
​	
  from index ii to j - 1j−1 is already checked to have no duplicate characters. We only need to check if s[j]s[j] is already in the substring s_{ij}s 
ij
​	
 .

To check if a character is already in the substring, we can scan the substring, which leads to an O(n^2)O(n 
2
 ) algorithm. But we can do better.

By using HashSet as a sliding window, checking if a character in the current can be done in O(1)O(1).

A sliding window is an abstract concept commonly used in array/string problems. A window is a range of elements in the array/string which usually defined by the start and end indices, i.e. [i, j)[i,j) (left-closed, right-open). A sliding window is a window "slides" its two boundaries to the certain direction. For example, if we slide [i, j)[i,j) to the right by 11 element, then it becomes [i+1, j+1)[i+1,j+1) (left-closed, right-open).

Back to our problem. We use HashSet to store the characters in current window [i, j)[i,j) (j = ij=i initially). Then we slide the index jj to the right. If it is not in the HashSet, we slide jj further. Doing so until s[j] is already in the HashSet. At this point, we found the maximum size of substrings without duplicate characters start with index ii. If we do this for all ii, we get our answer.
         */
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            HashSet<char> set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }
            return ans;
        }
    }
}