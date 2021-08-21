using RutujaLeetCode.Arrays;
using RutujaLeetCode.Dictionary;
using RutujaLeetCode.HashSetProblem;
using RutujaLeetCode.String;
using RutujaLeetCode.LinkedListSums;
using Xunit;
using System;
namespace UnitTest.Rutuja.LeetCode.Tests
{
    public class UnitTests
    {
        /// <summary>
        ///https://leetcode.com/problems/defanging-an-ip-address/
        ///Given a valid (IPv4) IP address, return a defanged version of that IP address.
        ///A defanged IP address replaces every period "." with "[.]".
        /// <param name="address"></param>
        /// <returns></returns>
        [Fact]
        public static void DefangingIPAddress ()
        {
            string address = "1.1.1.1";
            string ans = "1[.]1[.]1[.]1";

            var result = Arrays.DefangingIPAddress (address);
            Assert.Equal (ans, result);
        }


        /// <summary>
        ///https://leetcode.com/problems/palindrome-number/solution/
        // Given an integer x, return true if x is palindrome integer.
        //An integer is a palindrome when it reads the same backward as forward.For example, 121 is palindrome while 123 is not.
        /// <param name="x"></param>
        /// <returns></returns>
        [Theory]
        [InlineData (123, false)]
        [InlineData (-123, false)]
        [InlineData (120, false)]
        [InlineData (0, true)]
        [InlineData (12221, true)]
        public static void IsPalindrome (int inputNumber, bool expectedResult)
        {


            var result = Arrays.IsPalindrome (inputNumber);
            Assert.Equal (expectedResult, result);

        }

        /// <summary>
        ///https://leetcode.com/problems/palindrome-number/solution/
        // Given an integer x, return true if x is palindrome integer.
        //An integer is a palindrome when it reads the same backward as forward.For example, 121 is palindrome while 123 is not.
        /// <param name="x"></param>
        /// <returns></returns>
        [Theory]
        [InlineData ("LVIII", 58)]
        [InlineData ("IX", 9)]
        [InlineData ("MCMXCIV", 1994)]
        public static void RomanToInteger (string input, int output)
        {
            //string s = "XII";
            //int ans = 12;
            var result = Dictionary.RomanToInt (input);
            Assert.Equal (output, result);
        }

        /// <summary>
        ///https://leetcode.com/problems/palindrome-number/solution/
        // Given an integer x, return true if x is palindrome integer.
        //An integer is a palindrome when it reads the same backward as forward.For example, 121 is palindrome while 123 is not.
        /// <param name="x"></param>
        /// <returns></returns>
        [Fact]
        public static void LargestCommonPrefix ()
        {
            string [] s = new string [] { "dog", "racecar", "car" };//{ "flower", "flow", "flight" };
            string output = "";
            var result = StringManipulation.LongestCommonPrefix (s);
            Assert.Equal (output, result);
        }

        /// <summary>
        ///https://leetcode.com/problems/palindrome-number/solution/
        // Given an integer x, return true if x is palindrome integer.
        //An integer is a palindrome when it reads the same backward as forward.For example, 121 is palindrome while 123 is not.
        /// <param name="x"></param>
        /// <returns></returns>
        [Fact]
        public static void BuddyStrings ()
        {
            string s = "aaaaaaabc";
            string goal = "aaaaaaacb";
            var result = HashsetProblem.BuddyString (s, goal);
            Assert.True (result);
        }

        [Theory]
        [InlineData ("([}}])", false)]
        [InlineData ("()", true)]
        [InlineData ("()[]{}", true)]
        [InlineData ("(]", false)]
        [InlineData ("([)]", false)]
        [InlineData ("{[]}", true)]
        [InlineData (")(){}", false)]
        public static void ValidParanthesis (string s, bool output)
        {
            var result = StringManipulation.ValidParentheses (s);
            Assert.Equal (result, output);
        }


        [Fact]
        //[InlineData ([1,1,2], 2)]
        public static void DuplicatesFromSortedArray ()
        {
            int [] s = new int [] { 0,0,0,1,1,2};
            int output=2; 
            var result = HashsetProblem.Remove_Duplicates_from_Sorted_Array (s);
            Assert.Equal (result, output);
        }

        [Fact]
        //[InlineData ([1,1,2], 2)]
        public static void GreatestCandies ()
        {
            int [] s = new int [] { 2, 3, 5, 1, 3 };
            int extra = 3;
            var result = Arrays.GreatestCandies (s, extra);
           // Assert.Equal (result, );
        }

        [Fact]
        public static void MergeLinkedList()
        {
            ListNode l1 = new ListNode (1);
            Add (2);
            Add (3);
            void Add (int v)
            {
                ListNode curr = l1;
                ListNode temp = new ListNode (v);
                while (curr.next != null) {
                    curr = curr.next;
                }
                curr.next = temp;
            }

            var result = LinkedListSums.MergeTwoLists (l1);

        }
    }
}