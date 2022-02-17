using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    d [i]++;
            }

            var val = d.First ().Value;
            foreach (var i in d) {
                if (i.Value != val)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/rank-teams-by-votes/
        /// </summary>
        /// <param name="votes"></param>
        /// <returns></returns>
        public string RankTeams (string [] votes)
        {
           int len = votes [0].Length;
            Dictionary<char, int []> dict = new Dictionary<char, int []> ();

            //ABC
            for (int i = 0; i < votes.Length; i++) {
                var vote = votes [i];

                //A---B--C
                for (int j = 0; j < vote.Length; j++) {
                    if (!dict.ContainsKey (vote [j])) {
                        dict.Add (vote [j], new int [vote.Length]);
                    }
                    dict [vote [j]] [j]++;
                }
            }
            var abc = dict;
            int max = 0;
            StringBuilder sb = new StringBuilder ();
            var bb = dict.Values.ToArray();
            int loc = 0;
            for(int j=0;j<bb[0].Length;j++) {
                for(int i=0;i<bb.Length;i++) {
                    if(bb[i][j]>max) {
                        max = bb [i] [j];
                        loc = i;
                    }
                }
                max = 0;
                sb.Append (dict.ElementAt (loc).Key);
            }
                return sb.ToString();
        }
    }
}
