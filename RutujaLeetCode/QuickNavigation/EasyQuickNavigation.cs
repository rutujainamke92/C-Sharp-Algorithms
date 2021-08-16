﻿using System;
namespace RutujaLeetCode.QuickNavigation
{
    public static class EasyQuickNavigation
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
    }
}
