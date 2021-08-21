using System;
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
                }
                else {
                    sb.Append (item);
                }
            }
            return sb.ToString();
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
            IList<bool> ans = new List<bool>();
             Array.Sort<int> (nums);
            int max = nums [nums.Length-1];

            for (int i = 0; i < nums.Length; i++) {
                if ( (nums [i] + extra >= max))
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
           for(int i=0; i<nums.Length;i++) {
                for(int j = i+1; j< nums.Length;j++) {
                    if (nums [i] == nums [j])
                        count++;
                }
            }
           return count;
        }
    }
}