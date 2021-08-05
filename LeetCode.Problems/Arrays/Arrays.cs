using System;
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

        /// <summary>
        /// 7. Reverse Integer
        /// Given a signed 32-bit integer x, return x with its digits reversed. 
        /// If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int ReverseInteger(int x)
        {
            int y = 0;

            //if we negate -2,147,483,648  > 2,147,483,648 int will overflow
            if (x == int.MinValue)
                return 0;

            bool isNegative = x < 0;

            x= Math.Abs(x);

            while(x > 0)
            {
                if (y > (int.MaxValue - (x % 10)) / 10) return 0;
                y = (y * 10) + (x % 10);
                x /= 10;
            }

            return isNegative ? -y : y;
        }

        /// <summary>
        /// 7. Reverse Integer
        /// Given a signed 32-bit integer x, return x with its digits reversed. 
        /// If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int ReverseInteger1(int x)
        {        
            string num = x.ToString();
            char[] newNum = new char[num.Length];
            int i = num.Length - 1;
            int j = 0;
            int start = 0;

            if(num[0] == '-')
            {
                if (i >= 11) return 0;
                newNum[0] = '-';
                j++;
                start++;
            }

            while (i >= start)
            {
                newNum[j] = num[i];
                j++;
                i--;
            }

            try
            {
                var str = new String(newNum);
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}