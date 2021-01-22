using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    public class GainBestProfitFromMarket
    {
        public int MaxProfit(int[] prices)
        {
            var profit = 0;
            var maxProfit = 0;
            var len = prices.Length;
            var index = 0;
            var valley = int.MaxValue;
            var valleyIndex = 0;
            var peak = int.MinValue;
            var peakIndex = 0;
            while (index <= len - 1)
            {
                var current = prices[index];
                if (current < valley && index < len - 1)
                {
                    valley = current;
                    valleyIndex = index;
                    //reset peak
                    peak = valley;
                    peakIndex = index;
                }
                else if (current > valley && current > peak && index > 0)
                {
                    
                        peak = current;
                        peakIndex = index;
                        if (peakIndex > valleyIndex)
                        {
                            profit = peak - valley;
                            maxProfit = Math.Max(profit, maxProfit);
                        }

                }
                index++;
            }
            

            return maxProfit;
        }
    }
}