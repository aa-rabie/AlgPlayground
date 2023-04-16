using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPlayGroundApp.LeetCode.DynamicProgramming
{
    /*
     The Tribonacci sequence Tn is defined as follows: 
     T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.
    Given n, return the value of Tn.

    Constraints:
    0 <= n <= 37
    The answer is guaranteed to fit within a 32-bit integer, ie. answer <= 2^31 - 1
     */
    internal class TribonacciNumber
    {
        public int Tribonacci(int n)
        {
            var arr = new int[38];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 1;

            for (var i = 3; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2] + arr[i - 3];
            }

            return arr[n];
        }
    }
}
