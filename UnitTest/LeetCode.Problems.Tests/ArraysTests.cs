using LeetCode.Problems.Arrays;
using Xunit;

namespace UnitTest.LeetCode.Problems.Tests
{
    public static class ArraysTests
    {
        [Fact]
        public static void TestProblem1()
        {
            //Test TwoSum
            // LeetCode :: 1. Two Sum
            // https://leetcode.com/problems/two-sum/
            int[] nums = { 2, 7, 15, 11 };
            const int target = 9;
            int[] expectedResult = { 0, 1 };

            var result = Arrays.TwoSum(nums, target);
            Assert.True(System.Linq.Enumerable.SequenceEqual(expectedResult, result));

            var result1 = Arrays.TwoSum1(nums, target);
            Assert.True(System.Linq.Enumerable.SequenceEqual(expectedResult, result1));            
        }

        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(0, 0)]
        [InlineData(1534236469, 0)]
        [InlineData(-2147483648, 0)]
        public static void TestProblem7(int inputNumber, int expectedNumber)
        {
            //Test ReverseInteger
            // LeetCode :: 7. Reverse Integer
            // https://leetcode.com/problems/two-sum/
            var reversedNumber = Arrays.ReverseInteger(inputNumber);
            Assert.Equal<int>(expectedNumber, reversedNumber);
        }

        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(0, 0)]
        [InlineData(1534236469, 0)]
        [InlineData(-2147483648, 0)]
        public static void TestProblem7_1(int inputNumber, int expectedNumber)
        {
            //Test ReverseInteger
            // LeetCode :: 7. Reverse Integer
            // https://leetcode.com/problems/two-sum/
            var reversedNumber = Arrays.ReverseInteger1(inputNumber);
            Assert.Equal<int>(expectedNumber, reversedNumber);
        }
    }
}