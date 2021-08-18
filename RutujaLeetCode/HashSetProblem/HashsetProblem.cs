using System.Collections.Generic;
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

    }
}
