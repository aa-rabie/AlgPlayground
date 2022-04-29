using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-subarray/solution/
    /// </summary>
    public class MaxSubArrayProblem
    {
        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                int n = nums.Length;
                int currSum = nums[0], maxSum = nums[0];

                for (int i = 1; i < n; ++i)
                {
                    currSum = Math.Max(nums[i], currSum + nums[i]);
                    maxSum = Math.Max(maxSum, currSum);
                }
                return maxSum;
            }
        }

        public class MySolution
        {
            public int MaxSubArray(int[] nums)
            {
                if (nums == null || !nums.Any())
                    return 0;

                int i = 0;
               
                List<DataSegment> data = new List<DataSegment>(nums.Length * 2);
                List<Task<List<DataSegment>>> tasks = new List<Task<List<DataSegment>>>();
                while (i < nums.Length)
                {
                    tasks.Add(Build(nums,i,nums.Length-1));
                    i++;
                }

                Task.Run(async () => await Task.WhenAll(tasks)).Wait();
                foreach (var t in tasks)
                {
                    data.AddRange(t.Result);
                }
                var max = data.Max(s => s.Sum);
                return max;
            }

            public Task<List<DataSegment>> Build(int[] src, int start, int end)
            {
                List < DataSegment > data = new List<DataSegment>(end-start + 1);
                int index = start;
                while (start < src.Length && end < src.Length && index <= end)
                {
                    data.Add(new DataSegment(src, start, index++));
                    
                }
                TaskCompletionSource<List<DataSegment>> tsc = new TaskCompletionSource<List<DataSegment>>();
                tsc.SetResult(data);
                return tsc.Task;
            } 

            public class DataSegment
            {
                public DataSegment(int[] src, int start, int end)
                {
                    Start = start;
                    End = end;
                    Segment = new ArraySegment<int>(src, start, end - start + 1);
                    Sum = Segment.Sum();
                }
                public int Start { get; set; }
                public int End { get; set; }
                public ArraySegment<int> Segment { get; set; }
                public int Sum { get; set; }
            }
        }
    }
}