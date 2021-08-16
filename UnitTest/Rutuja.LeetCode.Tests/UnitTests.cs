using RutujaLeetCode.Arrays;
using RutujaLeetCode.Dictionary;
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
        public static void  IsPalindrome (int inputNumber, bool expectedResult)
        {
       

            var result = Arrays.IsPalindrome (inputNumber);
            Assert.Equal (expectedResult, result);

        }

        [Theory]
        [InlineData ("LVIII", 58)]
        [InlineData ("IX", 9)]
        [InlineData ("MCMXCIV",1994)]   
        public static void RomanToInteger (string input, int output)
        {
            //string s = "XII";
            //int ans = 12;
            var result = Dictionary.RomanToInt(input);
            Assert.Equal (output, result);
        }
    }
}