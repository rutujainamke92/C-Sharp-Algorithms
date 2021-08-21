using System.Collections.Generic;
using System.Linq;

namespace RutujaLeetCode.HashSetProblem
{
    public class HashsetProblem
    {
        /// <summary>
        /// Learn about Hashet https://coyote365-my.sharepoint.com/personal/rutuja_inamke_coyote_com/_layouts/OneNote.aspx?id=%2Fpersonal%2Frutuja_inamke_coyote_com%2FDocuments%2FRutuja%20%40%20Coyote%20Logistics%2C%20LLC&wd=target%28Google.one%7CE9BDCB60-B19F-264B-AC7D-7E0798EC0AF7%2FHashSet%7CA9F385FA-9193-AE4F-9D14-B61F254EA3C5%2F%29
        //  onenote:https://coyote365-my.sharepoint.com/personal/rutuja_inamke_coyote_com/Documents/Rutuja%20@%20Coyote%20Logistics,%20LLC/Google.one#HashSet&section-id={E9BDCB60-B19F-264B-AC7D-7E0798EC0AF7}&page-id={A9F385FA-9193-AE4F-9D14-B61F254EA3C5}&object-id={EF081A8C-F3F9-9241-AE51-61A328806E8F}&12
        /// </summary>
        /// <param name="s"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static bool BuddyString (string s, string goal)
        {
            //My Logic but its doesn't work for large numbers. 
            //if (string.IsNullOrEmpty (s) || s.Length!=goal.Length)
            //    return false;



            //for (int i = 0; i < s.Length; i++) {

            //    for (int j = 0; j < s.Length; j++) {
            //        char [] str = s.ToCharArray ();
            //        if (i == j)
            //            continue;

            //        var a =   str[i];
            //        str [i] = str [j];
            //        str [j] = a;

            //        string compare = new string (str);

            //        if (compare == goal) //{
            //            return true;
            //        //} else
            //            //continue;
            //    }
            //}

            //return false;

            //If length is not equal exit
            if (s.Length != goal.Length)
                return false;

            //Use hashset if value is same of s and goal example --> 'aaab', 'aaab'
            //if value is 'ab' and 'ab' it is not a BuddyString. Since no two values change to match goal.
            ////when strings are equal (aa = aa, set would have only a)
            HashSet<char> hash = new HashSet<char> ();

            if (s == goal) {
                foreach (var item in s) {
                    hash.Add (item);
                }
                if (hash.Count < s.Length)
                    return true;
            }
            //Store index for character which differs 
            var list = new List<int> ();
            for (int i = 0; i < s.Length; i++) {
                if (s [i] != goal [i])
                    list.Add (i);
            }
            if (list.Count == 2 && s [list [0]] == goal [list [1]] && s [list [1]] == goal [list [0]])
                return true;
            else return false;

        }

        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
        /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.It does not matter what you leave beyond the first k elements.
        /// Return k after placing the final result in the first k slots of nums.
        /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Remove_Duplicates_from_Sorted_Array(int [] nums)
        {
            //this solution did not work for online submission. This problem has lots of thumbs down hence skipped

            //if (nums.Length==0) 
            //return 0;

            //HashSet<int> ans = new HashSet<int> ();

            //for (int i = 0; i < nums.Length; i++) {
            //    ans.Add (nums [i]);
            //}
            //nums = ans.ToArray<int> ();

            //return nums.Count();


            //THis solution passes on websited
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++) {
                if (nums [j] != nums [i]) {
                    i++;
                    nums [i] = nums [j];
                }
            }
            return i + 1;

        }
    }
}
