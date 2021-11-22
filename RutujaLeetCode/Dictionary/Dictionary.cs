using System;
using System.Collections.Generic;
using System.Linq;

namespace RutujaLeetCode.Dictionary
{
    public class Dictionary
    {
        public static int RomanToInt (string s)
        {
            Dictionary<string, int> d = new Dictionary<string, int> ();
            d.Add ("I", 1);
            d.Add ("V", 5);
            d.Add ("X", 10);
            d.Add ("L", 50);
            d.Add ("C", 100);
            d.Add ("D", 500);
            d.Add ("M", 1000);
            int ans = d.GetValueOrDefault (s [s.Length - 1].ToString ());

            //start from backwards.
            //start from last digit and go backwards.
            //if current is greater than previous then subtract-like IX =9 (10>1| so | 10-1=9)
            //else add it to ans.

            for (int i = s.Length - 1; i > 0; i--) {
                if (d.GetValueOrDefault (s [i - 1].ToString ()) >= d.GetValueOrDefault (s [i].ToString ())) {
                    ans = ans + d.GetValueOrDefault (s [i - 1].ToString ());
                } else
                    ans = ans - d.GetValueOrDefault (s [i - 1].ToString ());

            }
            return ans;
        }

        /// <summary>
        /// https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool AreOccurrencesEqual (string s)
        {
            //cities.ElementAt (i).Key, 
            //cities.ElementAt (i).Value);
            Dictionary<char, int> d = new Dictionary<char, int> ();

            foreach (char i in s) {
                if (!d.ContainsKey (i))
                    d.Add (i, 1);

                else
                    //VV IMP how this works 
                    d[i]++;
            }

            var val = d.First().Value;
            foreach(var i in d) {
                if (i.Value != val)
                    return false;                
            }
            return true;
        }
    }
}
