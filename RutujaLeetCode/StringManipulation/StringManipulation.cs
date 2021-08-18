using System;
using System.Collections.Generic;

namespace RutujaLeetCode.String
{
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
            if (string.IsNullOrEmpty (s) || (s.Length%2!=0))
                return false;

            int count = 0;
            Dictionary<char, char> required = new Dictionary<char, char> ();
            required.Add ('(', ')');
            required.Add ('{', '}');
            required.Add ('[', ']');
            Stack<char> str = new Stack<char> ();

            for (int i = 0; i < s.Length; i++) {
                if ( required.ContainsKey(s[i]))
                {
                    //} {[()
                    //stack => )]}
                    str.Push (required.GetValueOrDefault(s[i]));
                    continue;
                }                                

                //})
                //pop==> )
                else if (str.Count == 0 || str.Pop () != s [i])
                        {
                        return false;
                }                    
            }
            
                return str.Count==0;
            
      

        }

    }
}
