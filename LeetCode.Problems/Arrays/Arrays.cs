using System.Collections.Generic;

namespace LeetCode.Problems.Arrays
{
    public static class Arrays
    {
        /// <summary>
        /// https://leetcode.com/problems/two-sum/
        /// 1. Two Sum
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            //define array of size 2 to store result
            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    // Skip if you are looking at the same number from the input array
                    if (i != j)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            result[0] = i;
                            result[1] = j;
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// https://leetcode.com/problems/two-sum/
        /// 1. Two Sum
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum1(int[] nums, int target)
        {
            //define array of size 2 to store result
            int[] result = new int[2];
                        
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if(map.ContainsKey(target - nums[i]))
                {
                    if(map.ContainsKey(target - nums[i]))
                        return new int[] { map[target - nums[i]], i };
                }
                map.Add(nums[i], i);            }

            return result;
        }
    }
}