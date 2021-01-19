using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.LeetCode.Arrays
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/546/
    // https://leetcode.com/problems/two-sum
    // problem/solution explained in => https://www.youtube.com/watch?v=U8B984M1VcU&feature=youtu.be
    public class TwoSum
    {
        internal class BruteForce
        {
            public int[] TwoSum(int[] nums, int target)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] == target - nums[i])
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                throw new ArgumentException("No two sum solution");
            }
        }

        internal class TwoStepHash
        {
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int,List<int>> hash = new Dictionary<int, List<int>>(nums.Length);
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!hash.ContainsKey(nums[i]))
                    {
                        hash.Add(nums[i], new List<int>(){i});
                    }
                    else
                    {
                        hash[nums[i]].Add(i);
                    }
                }

                for (int j = 0; j < nums.Length; j++)
                {
                    var complement = target - nums[j];
                    if(hash.ContainsKey(complement) && ContainsOtherValuesExcluding(hash[complement], j))
                        return new int[] {j, GetFirstValueExcluding(hash[complement],j).Value};
                }
                throw new ArgumentException("No two sum solution");
            }

            private bool ContainsOtherValuesExcluding(List<int> arr, int excludedValue)
            {
                return arr.Count(i => i != excludedValue) > 0;
                
            }

            private int? GetFirstValueExcluding(List<int> arr, int excludedValue)
            {
                var vals = arr.Where(i => i != excludedValue).ToList();
                if (!vals.Any())
                    return null;

                return vals.FirstOrDefault();
            }
        }

        internal class OneStepHash
        {
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>(nums.Length);
                for (int i = 0; i < nums.Length; i++)
                {

                    int complement = target - nums[i];
                    if (hash.ContainsKey(complement) && ContainsOtherValuesExcluding(hash[complement], i))
                        return new int[] { i, GetFirstValueExcluding(hash[complement], i).Value };

                    if (!hash.ContainsKey(nums[i]))
                    {
                        hash.Add(nums[i], new List<int>() { i });
                    }
                    else
                    {
                        hash[nums[i]].Add(i);
                    }
                }
                throw new ArgumentException("No two sum solution");
            }

            private bool ContainsOtherValuesExcluding(List<int> arr, int excludedValue)
            {
                return arr.Count(i => i != excludedValue) > 0;

            }

            private int? GetFirstValueExcluding(List<int> arr, int excludedValue)
            {
                var vals = arr.Where(i => i != excludedValue).ToList();
                if (!vals.Any())
                    return null;

                return vals.FirstOrDefault();
            }
        }

        internal class MyCustomSolution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, List<int>> Dictionary(int[] nums)
                {
                    var indices = new Dictionary<int,List<int>>();
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (indices.ContainsKey(nums[i]))
                        {
                            indices[nums[i]].Add(i);
                        }
                        else
                        {
                            indices.Add(nums[i], new List<int>(){i});
                        }
                    }
                    return indices;
                }

                var dict = Dictionary(nums);
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    // if complement exist in dictionary
                    // then we need to get its Index/position within array
                    // note : if same value exist in array multiple times
                    // then indices array will have multiple values
                    // in that case => we need to return first Index-Value
                    // from complementIndices where Index-Value <> i (loop variable)
                    // for example:
                    // the previous special case happens 
                    // if nums array => [3,3] & target value is 6
                    // then in that case
                    // dictionary will have single entry
                    // where key = 3
                    // & array of Indices contains 2 indices-values (0,1)
                    // when we enter this for loop for first time
                    // i will equal zero
                    // & nums[i] = 3
                    // & complement = 3
                    // & we have complement value in dictionary
                    // so in that case complment correct index-value should be 1
                    // not zero 
                    // because i = zero
                    if (dict.ContainsKey(complement))
                    {
                        var complementIndices = dict[complement];
                        if (complementIndices.Count(ind => ind != i) > 0)
                        {
                            return new int[]{i, complementIndices.First(ind => ind != i)};
                        }
                    }
                }
                throw new ArgumentException("No two sum solution");
            }
        }
    }
}