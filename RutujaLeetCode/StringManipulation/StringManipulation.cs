using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RutujaLeetCode.String
{
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
            if (carType == 3 && big > 0) {
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
            for (int i = 0; i < nums.Length - 1; i++) {
                if (nums [i + 1] > nums [i])
                    continue;
                else
                    if (count == 0) {
                    count++;
                    if (nums [i - 2] >= nums [i]) {
                        nums [i] = nums [i + 1];
                    }
                } else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/shuffle-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public static string ShuffleString (string s, int [] indices)
        {
            //Need string builder because we cannot 
            char [] t = new char [s.Length];
            //  StringBuilder sb = new StringBuilder ("", address.Length);

            for (int i = 0; i < indices.Length; i++) {
                t [indices [i]] = s [i];
            }
            return new string (t);
        }

        /// <summary>
        /// https://leetcode.com/problems/length-of-last-word/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLastWord (string s)
        {
            int counter = 0;
            // We are looking for the last word so let's go backward
            for (int i = s.Length - 1; i > -1; i--) {
                // a letter is found so count that letter
                if (s [i] != ' ') counter++;

                else if (counter > 0) //we found first space before a actual word
                    return counter;
            }
            return counter;
        }

        /// <summary>
        /// https://leetcode.com/problems/maximum-repeating-substring/
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static int MaxRepeating (string sequence, string word)
        {
            string w = word;
            int count = 0;
            while (true) {
                if (sequence.Contains (w)) {
                    w = w + word;
                    count++;
                } else return count;
            }
        }

        public static int MaxRepeating_WrittenByMe (string sequence, string word)
        {
            int count = 0; int j = 0;
            int i = 0;

            while (i < sequence.Length) {
                //if word matches sequence
                if (word [j] == sequence [i]) {
                    j++;
                    i++;
                }
                //else reset j of words pointer
                else if (j > 0) {
                    j = 0;
                } else {
                    i++;
                }
                //if word lenght , reset j
                if (j == word.Length) {
                    count++;
                    j = 0;
                }

            }

            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/goal-parser-interpretation/
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string Interpret (string command)
        {
            StringBuilder sb = new StringBuilder ();
            for (int i = 0; i < command.Length; i++) {
                if (command [i] == '(' && command [i + 1] == 'a') {
                    sb.Append ("al");
                    i = i + 3;
                } else
               if (command [i] == '(' && command [i + 1] == ')') {
                    sb.Append ("o");
                    i = i++;
                } else
                    if (command [i] == 'G')
                    sb.Append ("G");

            }
            return sb.ToString ();
        }

        /// <summary>
        /// https://leetcode.com/problems/count-items-matching-a-rule/
        /// </summary>
        /// <param name="items"></param>
        /// <param name="ruleKey"></param>
        /// <param name="ruleValue"></param>
        /// <returns></returns>
        public static int CountMatches (List<List<string>> items, string ruleKey, string ruleValue)
        {
            int count = 0;
            foreach (var item in items) {
                if ((ruleKey == "type" && item [0] == ruleValue) ||
                     (ruleKey == "color" && item [1] == ruleValue) ||
                     (ruleKey == "name" && item [2] == ruleValue)) {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/can-place-flowers/
        /// </summary>
        /// <param name="flowerbed"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool CanPlaceFlowers (int [] flowerbed, int n)
        {
            int count = 0;
            for (int i = 0; i < flowerbed.Length; i++) {
                var previous = (i == 0) || (flowerbed [i - 1] == 0);
                var next = (i == flowerbed.Length - 1) || (flowerbed [i + 1] == 0);
                if (flowerbed [i] == 0 && previous && next) {
                    count++;
                    i++;
                }

            }
            if (count >= n)
                return true;
            else return false;
        }

        //https://leetcode.com/problems/second-highest-salary/
        ///Write a SQL query to get the second highest salary from the Employee table.
        // S
        // Q
        // L

        //https://leetcode.com/problems/split-a-string-in-balanced-strings/
        public static int BalancedStringSplit (string s)
        {
            int count = 0;
            int incr = 0;
            foreach (var i in s) {
                if (i == 'R')
                    incr--;
                if (i == 'L')
                    incr++;
                if (incr == 0)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/first-unique-character-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FirstUniqChar (string s)
        {
            char item = ' ';
            int index = -1;

            int count;

            for (int i = 0; i < s.Length; i++) {
                count = 0;
                for (int j = 0; j < s.Length; j++) {

                    if (s [j] == s [i] && i != j) {
                        count++;
                        break;
                    }
                }

                if (count == 0) {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/sorting-the-sentence/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SortSentence (string s)
        {
            int count = 0;
            foreach (var ii in s) {
                if (ii.ToString () == " ")
                    count++;
            }
            string [] output = new string [count + 1];
            string [] strs = s.Split (" ");

            foreach (var item in strs) {
                char c = item [item.Length - 1];
                int index = (int)char.GetNumericValue (c);
                output [index - 1] = item.Remove (item.Length - 1, 1);
            }

            return string.Join (" ", output);
        }

        /// <summary>
        /// https://leetcode.com/problems/determine-color-of-a-chessboard-square/
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public static bool SquareIsWhite (string coordinates)
        {
            //abcdefg- ASCII starts with 97

            ///ABCDEFG - Ascii starts with 65
            int firstVal = (int)coordinates [0];
            firstVal -= 96;
            char second = coordinates [1];
            int secVal = (int)char.GetNumericValue (second);
            if ((firstVal % 2 == 0 && secVal % 2 == 0) || (firstVal % 2 != 0 && secVal % 2 != 0))
                return false;

            else return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/generate-a-string-with-characters-that-have-odd-counts/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string GenerateTheString (int n)
        {
            string [] str = new string [n];
            if (n % 2 != 0) {
                for (int i = 0; i < n; i++) {
                    str [i] = "a";
                }
            } else {
                for (int i = 0; i < n - 1; i++) {
                    str [i] = "a";
                }
            }


            if (n % 2 == 0) {
                str [n - 1] = "b";
            }
            return string.Join ("", str);
        }

        /// <summary>
        /// https://leetcode.com/problems/valid-palindrome-ii/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidPalindrome2 (string s)
        {
            //string [] input = new string [s.Length];

            //for(int i=0;i<s.Length;i++) {

            //}
            int left = 0; int right = s.Length - 1;
            while (right >= left) {
                if (s [left] == s [right]) {
                    left++; right--;
                    continue;
                } else if (s [left] != s [right]) {
                    return IsValid (s, left + 1, right) || IsValid (s, left, right - 1);
                } else return false;
            }
            return true;
        }

        public static bool IsValid (string s, int start, int end)
        {
            while (start <= end) {
                if (s [start] != s [end])
                    return false;
                start++; end--;
            }
            return true;
        }

        public static int CountBinarySubstrings (string s)
        {
            int [] groups = new int [s.Length];
            int k = 0;
            int result = 0;
            groups [0] = 1;
            for (int i = 0; i < s.Length - 1; i++) {
                if (s [i] == s [i + 1]) {
                    groups [k] = groups [k] + 1;
                } else {
                    k++;
                    groups [k] = 1;
                }
            }
            for (int i = 0; i < k; i++) {
                result = result + Math.Min (groups [i], groups [i + 1]);
            }
            return result;
        }

        /// <summary>
        /// https://leetcode.com/problems/valid-palindrome/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsPalindrome (string s)
        {
            if (s.Length == 1)
                return true;
            s = s.ToLower ();
            List<char> ch = new List<char> ();

            for (int i = 0; i < s.Length; i++) {
                if (char.IsLetterOrDigit (s [i])) {
                    ch.Add (s [i]);
                } else
                    continue;
            }
            //loop through whole ch, use 2 pointers, left and right values should match everytime
            //then return true else false

            for (int left = 0, right = ch.Count - 1; right >= left; left++, right--) {
                if (ch [left] != ch [right])
                    return false;
            }

            //Very goo way to do this..No need to user char.IsLetterorDigit or need to have
            //Another ch array 
            //while (i < j) {
            //    while (i < j && (s [i] < 'a' || s [i] > 'z') && (s [i] < '0' || s [i] > '9'))
            //        i++;

            //    while (i < j && (s [j] < 'a' || s [j] > 'z') && (s [j] < '0' || s [j] > '9'))
            //        j--;
            //    if (s [i] != s [j])
            //        return false;

            //    i++;
            //    j--;
            //}

            int [] a;
            a = new int [] { 1, 2 };
            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-string/submissions/
        /// //some modification
        /// </summary>
        /// <param name="s"></param>
        public static string ReverseString (string s)
        {
            char [] str = new char [s.Length];
            int j = 0;
            foreach (var item in s) {

                str [j] = item;
                j++;
            }

            char c;
            int lo = 0, hi = s.Length - 1;
            while (hi >= lo) {
                c = str [hi];
                str [hi] = str [lo];
                str [lo] = c;

                lo++;
                hi--;
            }
            return string.Join ("", str);
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-words-in-a-string-iii/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseWords (string s)
        {
            char [] ch = new char [s.Length];
            for (int i = 0; i < s.Length; i++) {
                ch [i] = s [i];
            }

            int hi, lo; int wordLength = 0;
            for (int j = 0; j < s.Length; j++) {
                if (ch [j] == ' ') {
                    lo = wordLength;
                    hi = j - 1;
                    while (lo <= hi) {
                        char temp = ch [hi];
                        ch [hi] = ch [lo];
                        ch [lo] = temp;
                        wordLength++;
                    }
                    if (wordLength % 2 == 0)
                        wordLength = wordLength * 2;
                    else
                        wordLength = wordLength * 2 + 1;

                }
            }
            return string.Join ("", ch);
        }

        public static string ReverseWords11 (string s)
        {
            StringBuilder final = new StringBuilder ();
            StringBuilder word = new StringBuilder ();


            int hi, i = 0; int wordLength = 0;
            for (int j = 0; j < s.Length; j++) {
                if (s [j] != ' ') {
                    word.Append (i);
                } else {
                    word.ToString ().Reverse ();
                    final.Append (word);
                    final.Append (" ");
                    word.Clear ();
                }



            }
            return string.Join ("", final);
        }

        /// <summary>
        /// https://leetcode.com/problems/is-subsequence/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsSubsequence (string s, string t)
        {
            int [] freq = new int [26]; //Dict of requency array to jot down all chars in t

            for (int i = 0; i < s.Length; i++) {
                freq [s [i] - 'a']++;
            }

            StringBuilder sb = new StringBuilder ();

            for (int i = 0; i < t.Length; i++) {
                if (freq [t [i] - 'a'] > 0) {
                    sb.Append (t [i]);
                    freq [t[i] - 'a']--;
                }
            }
            return sb.ToString () == s; ///string.Equals(sb.ToString(), t);
        }

    }
}