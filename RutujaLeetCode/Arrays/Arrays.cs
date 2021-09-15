﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RutujaLeetCode.Arrays
{
    public static class Arrays
    {
        /// <summary>
        ///https://leetcode.com/problems/build-array-from-permutation/
        /// Given a zero-based permutation nums (0-indexed), build an array ans of the same length
        /// where ans[i] = nums[nums[i]] for each 0 <= i < nums.length and return it.
        ///A zero-based permutation nums is an array of distinct integers from 0 to nums.length - 1 (inclusive).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int [] BuildArrayFromPermutation (int [] nums)
        {
            int [] ans = new int [nums.Length];
            for (int i = 0; i < nums.Length; i++) {
                ans [i] = nums [nums [i]];
            }
            return ans;
        }


        /// <summary>
        ///https://leetcode.com/problems/running-sum-of-1d-array/submissions/
        /// Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
        ///Return the running sum of nums
        ///Input: nums = [1,2,3,4]
        ///Output: [1,3,6,10]
        ///Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int [] RunninSum (int [] nums)
        {
            int [] ans = new int [nums.Length];
            ans [0] = nums [0];
            for (int i = 1; i < nums.Length; i++) {
                ans [i] = ans [i - 1] + nums [i];

            }
            return ans;

            //Option 2
            //for (int i = 1; i < nums.Length; i++) {
            //    nums [i] = nums [i - 1] + nums [i];

            //}
            //return nums;
        }

        /// <summary>
        ///https://leetcode.com/problems/defanging-an-ip-address/
        ///Given a valid (IPv4) IP address, return a defanged version of that IP address.
        ///A defanged IP address replaces every period "." with "[.]".
        /// <param name="address"></param>
        /// <returns></returns>
        public static string DefangingIPAddress (string address)
        {
            StringBuilder sb = new StringBuilder ("", address.Length);

            foreach (char item in address) {
                if (item == '.') {
                    sb.Append ("[.]");
                } else {
                    sb.Append (item);
                }
            }
            return sb.ToString ();
        }

        /// <summary>
        ///https://leetcode.com/problems/palindrome-number/solution/
        // Given an integer x, return true if x is palindrome integer.
        //An integer is a palindrome when it reads the same backward as forward.For example, 121 is palindrome while 123 is not.
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome (int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) return false;
            int rev = 0;
            int y = x;
            while (y != 0) {
                rev = rev * 10 + y % 10;
                y = y / 10;
            }
            if (x == rev)
                return true;

            else
                return false;
        }

        public static IList<bool> GreatestCandies (int [] nums, int extra)
        {
            LinkedListNode<int> abc;
            LinkedList<int> anc = new LinkedList<int> ();
            IList<bool> ans = new List<bool> ();
            Array.Sort<int> (nums);
            int max = nums [nums.Length - 1];

            for (int i = 0; i < nums.Length; i++) {
                if ((nums [i] + extra >= max))
                    ans.Add (true);
                else
                    ans.Add (false);
            }
            return ans;
        }

        public static int NumIdenticalPairs (int [] nums)
        {
            if (nums.Length == 0)
                return 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    if (nums [i] == nums [j])
                        count++;
                }
            }
            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/decode-xored-array/
        /// </summary>
        /// <param name="encoded"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static int [] DecodeXORArray (int [] encoded, int first)
        {
            //int x=1; int y=2;
            //int z = x ^ y;
            //IMP encode[0] = Arr[0] XOR Arr[1];
            //Arr[1] = en[0] XOR Arr[0];
            int [] arr = new int [encoded.Length + 1];
            arr [0] = first;
            for (int i = 0; i < encoded.Length; i++) {
                arr [i + 1] = (encoded [i] ^ arr [i]);
            }
            return arr;
        }

        /// <summary>
        /// https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SubtractProductAndSum (int n)
        {
            //My Solution
            //string s = Convert.ToString (n);
            //int [] input = new int [s.Length];
            //int i = 0;
            //while (n != 0) {
            //    input [i] = n % 10;
            //    n = n / 10;
            //    i++;
            //}
            //int sum = 0; int mul = 1;
            //foreach (var item in input) {
            //    sum = sum + item;
            //    mul = mul * item;
            //}

            //return mul - sum;

            //Optimized solution online
            string s = Convert.ToString (n);
            int sum = 0; int mul = 1;
            while (n > 0) {
                sum = sum + n % 10;
                mul = mul * n % 10;
                n = n / 10;
            }

            return mul - sum;
        }

        /// <summary>
        /// https://leetcode.com/problems/third-maximum-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ThridMax (int [] nums)
        {
            long max = long.MinValue;
            long sec = long.MinValue;
            long third = long.MinValue;
            for (int i = 0; i < nums.Length; i++) {
                    if (nums [i] == max || nums [i] == sec || nums [i] == third)
                        continue;

                if (nums [i] > max) {
                        third = sec;
                        sec = max;
                        max = nums [i];
                    }
                    else if(nums[i]>sec) {
                        third = sec;
                        sec = nums [i];
                    }
                    else if(nums[i]>third) {
                        third = nums [i];
                    }
                }
                //third = sec;
                //sec = max;
                if (third > long.MinValue    )
                    return (int)third;
                else return (int)max;
        }

        /*Very IMP Microsoft, Amazon, LinkedIn*/
        /// <summary>
        /// https://leetcode.com/problems/maximum-subarray/
        /// </summary>
        /// <returns></returns>
        public static int MaxSubArray(int [] nums)
        {
            //We can also do it using two for loops-->O(n^2)
            //And find easy sub array and compare max out of it. 
            //Linear soln -- TC-> O(n) --Easy explanation
            //https://www.youtube.com/watch?v=5WZl3MMT0Eg&ab_channel=NeetCode
            //if CurrSum is negative scratch that and start array from next. 

            /*int currSum = nums[0];
            int maxSum = nums[0];

            foreach(int i in nums) {
                if (currSum < 0)
                    currSum = 0;
                currSum = currSum + i;
                maxSum = Math.Max (currSum, maxSum);
            }
            return maxSum;*/

            //Another way to do it --> Nick WHite Vid

            int currSum = nums [0];
            int maxSum = nums [0];
            for(int i = 1; i < nums.Length; i++) { 
                currSum = Math.Max (currSum + nums[i], nums[i]);
                maxSum = Math.Max (currSum, maxSum);
            }
            return maxSum;
        }
    }
}
