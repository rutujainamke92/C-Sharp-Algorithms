﻿using RutujaLeetCode.Arrays;
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
using static RutujaLeetCode.Tree.LearningTree;
using RutujaLeetCode.Stack;
using RutujaLeetCode.MyMatrix;
using RutujaLeetCode;

//TODO : readd Graphs and Tree from old solution (RutujaPractice/ csharp)
//TODO : Another todo
//TODO : test commit
//TODO : for source tree//Sample changes    
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

            var result = LinkedListSums.MergeTwoLists (l1, l1);

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
        public static void AllPathsSoucreTarget ()
        {
            //VV IMP how to declare 2D array.
            int [] [] edges = {
                            new int[2]{1,2},
                            new int[1]{3},
                            new int[1]{3},
                            new int[]{ }
                           };

            var result = GraphProblems.AllPathsSourceTarget (edges);
            Assert.Equal (null, result);
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

        //[Fact]
        //public static void CallInsertVal ()
        //{
        //    LearningTreeDS createTree = new LearningTreeDS ();
        //    createTree.CreateTree ();
        //}

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
        public static void MinEatingSpeedn ()
        {
            int [] piles = new int [] { 312884470 };
            int h = 312884470;

            var result = Arrays.MinEatingSpeed (piles, h);
            Assert.Equal (2, result);

        }

        [Fact]
        public static void ValidPalindrome ()
        {
            string s = "abca";
            var result = StringManipulation.ValidPalindrome2 (s);
            Assert.True (result);
        }

        [Fact]
        public static void CountBinarySubstrings ()
        {
            string s = "000111";
            var result = StringManipulation.CountBinarySubstrings (s);
            Assert.Equal (3, result);

        }


        [Fact]
        public static void IsPalindromeString ()
        {
            string s = "A man, a plan, a canal: Panama";
            var result = StringManipulation.IsPalindrome (s);
            Assert.Equal (false, result);

        }

        [Fact]
        public static void FourSun ()
        {
            //Arrange
            int [] nums = { 2, 2, 2, 2 };
            List<IList<int>> answer = new List<IList<int>> ();
            answer.Add (new List<int> () { 2, 2, 2, 2 });

            //Act
            var result = Arrays.FourSum (nums, 8);

            //Assert
            Assert.Equal (answer, result);

        }


        [Fact]
        public static void DeleteDuplicatefromLinkedList ()
        {
            ListNode l1 = new ListNode (1);
            Add (1);
            Add (1);
            Add (2);
            void Add (int v)
            {
                ListNode curr = l1;
                ListNode temp = new ListNode (v);
                while (curr.next != null) {
                    curr = curr.next;
                }
                curr.next = temp;
            }

            var result = LinkedListSums.DeleteDuplicates (l1);


        }


        [Fact]
        public static void SortedSquares ()
        {
            //Arrange
            int [] nums = { 1, 2, 3, 0 };

            //Act
            var result = Arrays.SortedSquares (nums);

            //Assert
            Assert.Equal (new int [] { 1, 2, 3, 1 }, result);

        }


        [Fact]
        public static void FindAnagrams ()
        {
            //Arrange
            string s = "cbaebabacd"; string p = "abc";

            //Act
            var result = Arrays.FindAnagrams (s, p);

            //Assert
            Assert.Equal (new List<int> () { 0, 6 }, result);

        }

        [Fact]
        public static void HasCycle ()
        {
            ListNode l1 = new ListNode (3);
            Add (2);
            Add (0);
            Add (4);
            //AddCycleAtLast ();

            void Add (int v)
            {
                ListNode curr = l1;
                ListNode temp = new ListNode (v);
                while (curr.next != null) {
                    curr = curr.next;
                }
                curr.next = temp;
            }
            void AddCycleAtLast ()
            {
                ListNode curr = l1;
                ListNode temp = new ListNode ();
                temp.next = l1;
                while (curr.next != null) {
                    curr = curr.next;
                    temp = temp.next;
                }
                curr.next = temp;
            }

            var result = LinkedListSums.HasCycle (l1);
            Assert.Equal (true, result); ;


        }

        [Fact]
        public static void FindKthPositive ()
        {
            //Arrange
            int [] nums = { 1, 2, 3, 4 };
            int k = 2;
            //Act
            var result = Arrays.FindKthPositive (nums, k);

            //Assert
            Assert.Equal (6, result);

        }

        [Fact]
        public static void BackspaceCompare ()
        {
            //Arrange
            string s = "y#fo##f";
            string t = "y#f#o##f";
            //Act
            var result = Arrays.BackspaceCompare (s, t);

            //Assert
            Assert.True (result);

        }

        [Fact]
        public static void ValidWordAbbreviation ()
        {
            //Arrange
            string s = "a";
            string t = "01";
            //Act
            var result = Arrays.ValidWordAbbreviation (s, t);

            //Assert
            Assert.True (result);

        }

        [Fact]
        public static void ReverseString ()
        {
            //Arrange
            string s = "rutuja";
            //Act
            var result = StringManipulation.ReverseString (s);

            //Assert
            Assert.Equal ("ajutur", result);

        }

        [Fact]
        public static void ReverseWords ()
        {
            //Arrange
            string s = "rutuja is great";
            //Act
            var result = StringManipulation.ReverseWords (s);

            //Assert
            Assert.Equal ("ajutur", result);
        }

        [Fact]
        public static void CopyRandomList ()
        {
            RutujaLeetCode.LinkedListSums.Node l1 = new RutujaLeetCode.LinkedListSums.Node (0);
            LinkedListSums.Add (1, l1, 3);
            LinkedListSums.Add (2, l1, 1);
            LinkedListSums.Add (3, l1, 3);

            var result = LinkedListSums.CopyRandomList2 (l1);

        }

        [Fact]
        public static void IsSubsequnce ()
        {
            //Arrange
            string s = "rutu";
            string t = "rutuja";
            //Act
            var result = StringManipulation.IsSubsequence (s, t);

            //Assert
            Assert.Equal (true, result);
        }

        [Fact]
        public static void AddStrings ()
        {
            //Arrange
            string s = "1234";
            string t = "92";
            //Act
            var result = StringManipulation.AddStrings (s, t);

            //Assert
            Assert.Equal ("1246", result);
        }

        [Fact]
        public static void RightSideView ()
        {
            LearningTree createTree = new LearningTree ();
            var root = createTree.insertDFS (new int [] { 1, 2, 3, 4, 5 });

            var result = LearningTree.RightSideView (root);
        }

        [Fact]
        public static void DFSInOrderTraversalwithStack ()
        {
            LearningTree lt = new LearningTree ();

            LearningTree.Node root = new LearningTree.Node (1);
            root.left = new LearningTree.Node (2);
            root.right = new LearningTree.Node (3);
            root.left.left = new LearningTree.Node (4);
            root.left.right = new LearningTree.Node (5);
            //var root = createTree.insertDFS (new int [] { 1,2,3,4,5});

            var result = LearningTree.DFSInOrderTraversalwithStack (root);

            Assert.Equal (new List<int> () { 4, 2, 5, 1, 3 }, result);
        }

        [Fact]
        public static void LowestCommonAncestor ()
        {
            LearningTree lt = new LearningTree ();

            TreeNode root = new TreeNode (1);
            root.left = new TreeNode (2);
            root.right = new TreeNode (3);
            root.left.left = new TreeNode (4);
            root.left.right = new TreeNode (5);

            TreeNode p = new TreeNode (2);
            TreeNode q = new TreeNode (5);

            TreeNode ans = new TreeNode (2);

            var result = lt.LowestCommonAncestor (root, p, q);

            Assert.Equal (ans, result);
        }

        [Fact]
        public static void AverageOfLevels ()
        {
            //Arrange
            TreeNode root = new TreeNode (3);
            root.left = new TreeNode (9);
            root.right = new TreeNode (20);
            root.right.left = new TreeNode (15);
            root.right.right = new TreeNode (7);

            List<double> ans = new List<double> () { 3.00000, 14.50000, 11.00000 };

            //Act
            var result = LearningTree.AverageOfLevels (root);

            //Assert
            Assert.Equal (ans, result);
        }

        [Fact]
        public static void reverse ()
        {
            string s = "rutuja";
            var result = StringManipulation.reverse (s);
            Assert.Equal ("ajutur", result);
        }

        [Fact]
        public static void NumSqures ()
        {
            int n = 12;
            var result = NumberProblems.NumSquares (n, 0);
            Assert.Equal (3, result);
        }

        [Fact]
        public static void MinStack ()
        {
            MinStack minStack = new MinStack ();
            minStack.Push (-2);
            minStack.Push (0);
            minStack.Push (-3);
            minStack.GetMin (); // return -3
            minStack.Pop ();
            minStack.Top ();    // return 0
            minStack.GetMin (); // return -2
                                // var result = NumberProblems.NumSquares (n, 0);
                                // Assert.Equal (3, result);
        }

        [Fact]
        public static void MaxStack ()
        {
            MaxStack maxstack = new MaxStack ();
            maxstack.Push (5);
            maxstack.Push (1);
            maxstack.PopMax ();//5
            maxstack.PeekMax ();//5          
        }

        [Fact]
        public static void EvalRPN ()
        {
            string [] tokens = new string [] { "2", "1", "+", "3", "*" };
            StackProblems st = new StackProblems ();
            var result = st.EvalRPN (tokens);
        }


        [Fact]
        public static void CanVisitAllRooms ()
        {
            IList<IList<int>> rooms = new List<IList<int>> () { new List<int> () { 1, 3 }, new List<int> () { 3, 0, 1 }, new List<int> () { 2 }, new List<int> { 0 } };
            var result = Arrays.CanVisitAllRooms (rooms);
            Assert.Equal (true, result);

        }

        [Fact]
        public static void UpdateMatrix ()
        {
            IList<IList<int>> rooms = new List<IList<int>> () { new List<int> () { 1, 3 }, new List<int> () { 3, 0, 1 }, new List<int> () { 2 }, new List<int> { 0 } };
            int [] [] mat = new int [] [] { new int [] { 0, 0, }, new int [] { 0, 1, 0 }, new int [] { 1, 1, 1 } };
            int [] [] ans = new int [] [] { new int [] { 0, 0, 0 }, new int [] { 0, 1, 0 }, new int [] { 1, 2, 1 } };
            Matrix2DArray matrix2DArray = new Matrix2DArray ();
            var result = matrix2DArray.UpdateMatrix (mat);
            Assert.Equal (ans, result);

        }

        [Fact]
        public static void serialize ()
        {
            //Arrange
            TreeNode root = new TreeNode (1);
            root.left = new TreeNode (2);
            root.right = new TreeNode (3);
            root.right.left = new TreeNode (4);
            root.right.right = new TreeNode (5);


            //Act
            LearningTree lt = new LearningTree ();
            // var result = lt.serialize (root);
            var result1 = lt.deserialize ("1,2,#,#,3,4,#,#,5,#,#,");

            //Assert
            Assert.Equal ("1,2,#,#,3,4,#,#,5,#,#,", "");
        }

        [Fact]
        public static void SwapPairs ()
        {
            ListNode l1 = new ListNode (1);
            LinkedListSums.Add (2, l1);
            LinkedListSums.Add (3, l1);
            LinkedListSums.Add (4, l1);

            var result = LinkedListSums.SwapPairs (l1);

        }

        [Fact]
        public static void MergeTwoLists2 ()
        {
            ListNode l1 = new ListNode (1);
            LinkedListSums.Add (2, l1);

            ListNode l2 = new ListNode (1);
            LinkedListSums.Add (2, l2);
            LinkedListSums.Add (4, l2);

            var result = LinkedListSums.MergeTwoLists2 (l1, l2);

        }
        [Fact]
        public static void KthGrammar ()
        {
            var result = StringManipulation.KthGrammar (2, 2);
        }

        [Fact]
        public static void CanAttendMeetings ()
        {
            var input = new int [2] [];
            input [0] = new int [] { 5, 8 };
            input [1] = new int [] { 6, 8 };
            var result = Arrays.CanAttendMeetings (input);
        }


        [Fact]
        public static void KthGrammar2 ()
        {
            int n = 3, k = 3;
            var result = Recursion.KthGrammar (n, k);
        }
    }
}