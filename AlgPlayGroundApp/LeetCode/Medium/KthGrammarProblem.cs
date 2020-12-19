using System;
using System.Collections.Generic;
using System.Text;

namespace AlgPlayGroundApp.LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/k-th-symbol-in-grammar/
    /// </summary>
    public class KthGrammarProblem
    {
        /*
         On the first row, we write a 0. Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.

            Given row N and index K, return the K-th indexed symbol in row N. (The values of K are 1-indexed.) (1 indexed).
        */

        public class Solution
        {
            public int KthGrammar(int N, int K)
            {
                if (N == 1) return 0;
                return (~K & 1) ^ KthGrammar(N - 1, (K + 1) / 2);
            }

        }
    }
}