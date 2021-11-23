using RutujaLeetCode.Arrays;
using RutujaLeetCode.Dictionary;
using RutujaLeetCode.HashSetProblem;
using RutujaLeetCode.String;
using RutujaLeetCode.LinkedListSums;
using Xunit;
using RutujaLeetCode.IntProblems;
using RutujaLeetCode.Graphs;
using System;
using System.Collections.Generic;
using RutujaLeetCode.Tree;

//TODO : readd Graphs and Tree from old solution (RutujaPractice/ csharp)
//TODO : Another todo
//TODO : test commit
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
            int [] s = new int [] { 0, 0, 0, 1, 1, 2 };
            int output = 2;
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
        public static void MergeLinkedList ()
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

            //var result = LinkedListSums.MergeTwoLists (l1);

        }

        [Fact]
        public static void CountPrimes ()
        {

            var result = NumberProblems.CountPrimes (100);
            Assert.Equal (25, result);
        }

        [Fact]
        public static void JwelesinStones ()
        {

            var result = NumberProblems.CountPrimes (100);
            Assert.Equal (25, result);
        }

        [Fact]
        public static void RemoveElement ()
        {
            int [] input = new int [] { 3, 3, 2, 3 };

            var result = NumberProblems.RemoveElement (input, 3);
            Assert.Equal (1, result);
        }

        [Fact]
        public static void FindSubstring ()
        {
            string haystack = "haha";
            string needle = "a";
            var result = StringManipulation.strStrFindSubstring (haystack, needle);
            Assert.Equal (1, result);
        }

        [Fact]
        public static void ParkingSystem ()
        {
            string haystack = "haha";
            string needle = "a";
            var result = StringManipulation.strStrFindSubstring (haystack, needle);
            Assert.Equal (1, result);
        }

        [Fact]
        public static void CanBeIncreasing ()
        {
            int [] input = new int [] { 2, 3, 1, 2 };
            var res = NumberProblems.CanBeIncreasing (input);
            Assert.True (res);
        }

        [Theory]
        [InlineData (new int [] { 1 }, 0, 0)]
        //[InlineData (new int [] { 1, 3, 5, 6 }, 1, 0)]
        //[InlineData (new int [] { 1, 3, 5, 6 }, 3, 1)]
        //[InlineData (new int [] { 1, 3, 5, 6 }, 6, 3)]
        //[InlineData (new int [] { 1, 3, 5, 6 }, 2, 0)]
        //[InlineData (new int [] { 1, 3, 5, 6 }, 7, 0)]

        public static void SearchInsert (int [] nums, int target, int output)
        {
            var result = NumberProblems.SearchInsert (nums, target);
            Assert.Equal (result, output);
        }

        [Fact]

        public static void SearchInsert1 ()
        {
            int [] input = new int [] { 1, 3, 5, 6 };
            var result = NumberProblems.SearchInsert (input, 6);
            Assert.Equal (3, result);
        }


        [Fact]

        public static void ShuffleString ()
        {
            string s = "codeleet";
            int [] indices = new int [] { 4, 5, 6, 7, 0, 2, 1, 3 };
            var result = StringManipulation.ShuffleString (s, indices);
            Assert.Equal ("leetcode", result);
        }


        [Fact]
        public static void DecodeXORArray ()
        {
            int [] encoded = new int [] { 6, 2, 7, 3 };
            int first = 4;
            int [] output = new int [] { 4, 2, 0, 7, 4 };
            var result = Arrays.DecodeXORArray (encoded, first);
            Assert.Equal (output, result);
        }

        [Fact]
        public static void ThridMax ()
        {
            int [] input = new int [] { 2, 2, 3, 1 };
            var result = Arrays.ThridMax (input);
            Assert.Equal (1, result);
        }

        [Fact]
        public static void LengthOfLastWord ()
        {
            string s = "Hello World  ";
            var result = StringManipulation.LengthOfLastWord (s);
            Assert.Equal (5, result);
        }


        [Fact]
        public static void PlusOne ()
        {
            int [] input = new int [] { 7, 2, 8, 5, 0, 9, 1, 2, 9, 5, 3, 6, 6, 7, 3, 2, 8, 4, 3, 7, 9, 5, 7, 7, 4, 7, 4, 9, 4, 7, 0, 1, 1, 1, 7, 4, 0, 0, 6 };
            int [] output = new int [] { 7, 2, 8, 5, 0, 9, 1, 2, 9, 5, 3, 6, 6, 7, 3, 2, 8, 4, 3, 7, 9, 5, 7, 7, 4, 7, 4, 9, 4, 7, 0, 1, 1, 1, 7, 4, 0, 0, 7 };

            var result = NumberProblems.PlusOne2 (input);
            Assert.Equal (output, result);
        }

        [Fact]
        public static void SquareRoot ()
        {
            int x = 2147395600;
            var result = NumberProblems.SquareRoot (x);
            Assert.Equal (46340, result);
        }

        [Fact]
        public static void MaxRepeating ()
        {
            string sequence = "aaabaaaabaaabaaaabaaaabaaaabaaaaba";
            string word = "aaaba";
            var result = StringManipulation.MaxRepeating (sequence, word);
            Assert.Equal (5, result);
        }

        [Fact]
        public static void NumberOfSteps ()
        {
            int num = 8;
            var result = NumberProblems.NumberOfSteps (num);
            Assert.Equal (4, result);
        }

        [Fact]
        public static void DecompressRLElist ()
        {
            int [] num = new int [] { 1, 2, 3, 4 };
            var result = NumberProblems.DecompressRLElist (num);
            Assert.Equal (new int [] { 2, 4, 4, 4 }, result);
        }

        [Fact]
        public static void CreateTargetArray ()
        {
            int [] nums = new int [] { 0, 1, 2, 3, 4 };
            int [] index = new int []
                { 0, 1, 2, 2, 1};
            var result = NumberProblems.CreateTargetArray (nums, index);
            Assert.Equal (new int [] { 0, 4, 1, 3, 2 }, result);
        }


        [Fact]
        public static void CountMatches ()
        {
            List<List<string>> items = new List<List<string>> ();
            for (int i = 0; i < 3; i++) {
                List<string> Data = new List<string> ();
                Data.Add ("phone ");
                Data.Add ("blue ");
                Data.Add ("pixel ");
                items.Add (Data);
            }
            var result = StringManipulation.CountMatches (items, "color", "blue");
            Assert.Equal (0, result);
        }

        [Fact]
        public static void CanPlaceFlowers ()
        {
            int [] flowerbed = new int [] { 1, 0, 0, 0, 1 };
            int n = 2;
            var result = StringManipulation.CanPlaceFlowers (flowerbed, n);
            Assert.True (result);
        }

        [Fact]
        public static void CheckPerfectNumber ()
        {
            int n = 28;
            var result = NumberProblems.CheckPerfectNumber (n);
            Assert.Equal (true, result);
        }

        [Fact]
        public static void FirstUniqueChar ()
        {
            string s = "aabb";
            var result = StringManipulation.FirstUniqChar (s);
            Assert.Equal (2, result);
        }

        [Fact]
        public static void FindCenter ()
        {
            //VV IMP how to declare 2D array.
            int [] [] edges = {
                            new int[2]{1,2},
                            new int[2]{3,2},
                            new int[2]{2,4},
                           };

            var result = GraphProblems.FindCenter (edges);
            Assert.Equal (2, result);
        }

        [Fact]
        public static void SortSentence ()
        {
            string str = "sentence4 a3 is2 This1";
            var result = StringManipulation.SortSentence (str);
            Assert.Equal ("This is a sentence", result);
        }


        [Fact]
        public static void SquareIsWhite ()
        {
            string coordinates = "a2";
            var result = StringManipulation.SquareIsWhite (coordinates);
            Assert.Equal (true, result);
        }

        [Fact]
        public static void PivotIndex ()
        {
            int [] nums = new int [] { 1, 7, 3, 6, 5, 6 };
            var result = Arrays.PivotIndex (nums);
            Assert.Equal (3, result);
        }

        [Fact]
        public static void ValidMountainArray ()
        {
            int [] nums = new int [] { 1, 3, 2 };
            var result = Arrays.ValidMountainArray (nums);
            Assert.Equal (true, result);
        }

        [Fact]
        public static void TwoSum ()
        {
            int [] nums = new int [] { 3, 3 };
            int target = 6;
            var result = Arrays.TwoSum (nums, target);
            Assert.Equal (new int [] { 1, 2 }, result);
        }


        [Fact]
        public static void Intersect ()
        {
            int [] nums1 = new int [] { 1, 2, 3, 3 };
            int [] nums2 = new int [] { 3, 3 };
            var result = Arrays.Intersect (nums1, nums2);
            Assert.Equal (new int [] { 3, 3 }, result);
        }

        [Fact]
        public static void MaxProfit ()
        {
            int [] nums1 = new int [] { 2, 4, 1 };
            var result = Arrays.MaxProfit (nums1);
            Assert.Equal (5, result);
        }

        [Fact]
        public static void CallInsertVal ()
        {
            LearningTreeDS createTree = new LearningTreeDS ();
            createTree.CreateTree ();
        }

        [Fact]
        public static void GraphCallBFS ()
        {
            Graph g = new Graph (5);
            g.mainMethod ();
            Console.ReadKey ();

        }

        [Fact]
        public static void FindJudge ()
        {
            //V imp Jagged Array! 
            int [] [] trust = new int [] [] {
                new int [] { 1, 2 },
                new int [] { 1, 3 },
                new int [] { 2, 1 },
                new int [] { 2, 3 },
                new int [] { 1, 4 },
                new int [] { 4, 3 },
                new int [] { 4, 1 }};
            int n = 4;
            GraphProblems g = new GraphProblems ();
            var result = g.Findjudge (n, trust);
            Assert.Equal (3, result);
        }

        [Fact]
        public static void IsSymmetric ()
        {
            LearningTreeDS createTree = new LearningTreeDS ();

            var result = createTree.IsSymmetric ();
            Assert.True (result);
        }

    }
}