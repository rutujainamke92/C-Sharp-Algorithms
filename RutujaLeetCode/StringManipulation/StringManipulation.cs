﻿using System;
using System.Collections.Generic;

namespace RutujaLeetCode.String
{
    public class StringManipulation
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-common-prefix/
        /// Write a function to find the longest common prefix string amongst an array of strings.
        /// If there is no common prefix, return an empty string "".
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix (string [] strs)
        {
            if (strs.Length == 0)
                return "";
            string compare = strs [0];


            for (int i = 0; i < strs.Length; i++) {
                while (compare.Length > 0) {

                    //imp step
                    if (strs [i].IndexOf (compare) == 0) {
                        break;
                    } else {
                        compare = compare.Substring (0, compare.Length - 1);
                    }
                }
            }

            return compare;

        }


        public static bool ValidParentheses (string s)
        {
            if (string.IsNullOrEmpty (s) || (s.Length % 2 != 0))
                return false;

            Dictionary<char, char> required = new Dictionary<char, char> ();
            required.Add ('(', ')');
            required.Add ('{', '}');
            required.Add ('[', ']');
            Stack<char> str = new Stack<char> ();

            for (int i = 0; i < s.Length; i++) {
                if (required.ContainsKey (s [i])) {
                    //} {[()
                    //stack => )]}
                    str.Push (required.GetValueOrDefault (s [i]));
                    continue;
                }
                //})
                //pop==> )
                else if (str.Count == 0 || str.Pop () != s [i]) {
                    return false;
                }
            }
            return str.Count == 0;
        }


        /// <summary>
        /// https://leetcode.com/problems/jewels-and-stones/
        /// You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have. Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
        ///Letters are case sensitive, so "a" is considered a different type of stone from "A".
        /// </summary>
        /// <param name="jewels"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int NumJewelsInStones (string jewels, string stones)
        {
            HashSet<char> jewel = new HashSet<char> ();
            int count = 0;
            foreach (char s in jewels) {
                jewel.Add (s);
            }

            foreach (char s in stones) {
                if (jewel.Contains (s)) {
                    count++;
                }
            }
            return count;
        }


        /// <summary>
        /// https://leetcode.com/problems/implement-strstr/
        /// Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
        /// Return 0 if needle is empty.
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public static int strStrFindSubstring (string haystack, string needle)
        {
            if (needle.Length == 0) {
                return 0;
            }
            for (int i = 0; i < haystack.Length; i++) {

                int k = i;
                int j = 0;
                while (k < haystack.Length && needle [j] == haystack [k]) {
                    if (j == needle.Length - 1) {
                        return i;
                    }
                    k++; j++;
                }
            }

            return -1;


            //Option2 - using inbuilt Substring
            //for (int i = 0; i < haystack.Length; i++) {

            //    if (haystack.Substring (i, needle.Length) == needle) {
            //        return i;
            //    }
            //}
            //return 0;

        }
        public bool CanBeIncreasing (int [] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length-1; i++) {
                if (nums [i + 1] > nums [i])
                    continue;
                else
                    if (count == 0 ) {
                     count++;
                    if(nums[i-2]>=nums[i]) {
                        nums [i] = nums [i + 1];
                    }
                }
                else
                    return false;
            }
            return true;
        }
    }
    /// <summary>
    /// https://leetcode.com/problems/design-parking-system/
    /// </summary>
    public class ParkingSystem
    {
        public int big;
        public int medium;
        public int small;
        public ParkingSystem (int big, int medium, int small)
        {
            this.big = big;
            this.medium = medium;
            this.small = small;
        }

        public bool AddCar (int carType)
        {
            if(carType==3 && big>0) {
                big--;
                return true;
            }
            if (carType == 2 && medium > 0) {
                medium--;
                return true;
            }
            if (carType == 1 && small > 0) {
                small--;
                return true;
            }

            return false;
        }
    }
}