using System;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    // https://leetcode.com/problems/longest-common-prefix/description/
    // Write a function to find the longest common prefix string amongst an array of strings.

    // If there is no common prefix, return an empty string "".
    /// </summary>
    public class LongestCommonPrefix
    {
        public string Solution(string[] strs)
        {
            if (strs == null || strs.Length == 0) 
                return string.Empty;

            if(strs.Length == 1 ) { return strs[0]; }

            var prefix = strs[0]; // Take first item in list as prefix 

            // loop through all items (excluding the prefix) 
            for (var i = 1; i < strs.Length; i++)
            {
                // remove last character from prefix Until both words have same prefix
                while (strs[i].IndexOf(prefix, StringComparison.Ordinal) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }

                // if prefix is empty then return empty because there is nothing in-common
                if (string.IsNullOrEmpty(prefix))
                    return string.Empty;
            }

            return prefix;
        }
    }
}