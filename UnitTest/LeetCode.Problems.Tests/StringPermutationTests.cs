
using LeetCode.Problems.Strings;
using Xunit;

namespace UnitTest.LeetCode.Problems.Tests
{
    public static class StringPermutationTests
    {
        [Fact]
        public static void DoTest()
        {
            //add two numbers
            //another comment to test 
            int a = 2 + 5;

            var alphabets = "abcdefg";

            var permutations = Permutations.ComputeDistinct(alphabets);
            Assert.True(permutations.Count == 720);

            var one = "abcdefg";
            var two = "dabcgfe";
            Assert.True(Permutations.IsAnargram(one, two) == true);

            one = "123456";
            two = "789123";
            Assert.True(Permutations.IsAnargram(one, two) == false);

            one = "abc";
            two = "bbb";
            Assert.True(Permutations.IsAnargram(one, two) == false);

            one = "acdf";
            two = "bcde";
            Assert.True(Permutations.IsAnargram(one, two) == false);

            one = "I am legion";    // L is small
            two = "Legion I am";    // L is capital
            Assert.True(Permutations.IsAnargram(one, two) == false);

            one = "I am legion";    // L is small
            two = "legion I am";    // L is small
            Assert.True(Permutations.IsAnargram(one, two) == true);

            var number1 = 20;
            var number2 = 25;
            var c = 45;
            Assert.True(Permutations.AddNumbers(number1, number2) == c);
        }
    }
}
