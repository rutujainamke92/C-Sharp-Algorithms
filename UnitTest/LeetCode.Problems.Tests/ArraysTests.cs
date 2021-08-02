using LeetCode.Problems.Arrays;
using Xunit;

namespace UnitTest.LeetCode.Problems.Tests
{
    public static class ArraysTests
    {
        [Fact]
        public static void TestProblems()
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
    }
}