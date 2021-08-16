using System;
using System.Collections.Generic;

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
            int ans = d.GetValueOrDefault(s [s.Length - 1].ToString());

            //start from backwards.
            //start from last digit and go backwards.
            //if current is greater than previous then subtract-like IX =9 (10>1| so | 10-1=9)
            //else add it to ans.

            for (int i = s.Length - 1; i > 0; i --) {
                if (d.GetValueOrDefault (s [i - 1].ToString ()) >=  d.GetValueOrDefault(s [i].ToString ()))
                {
                    ans = ans + d.GetValueOrDefault (s [i-1].ToString ());
                }
                else
                    ans = ans - d.GetValueOrDefault (s [i-1].ToString ());

            }
            return ans;
        }
    }
}
//foreach (var item in s) {
//    foreach (var pair in d) {
//        if (item.ToString () == pair.Key)
//            ans = ans + pair.Value;
//        Console.WriteLine (ans);

//    }
//}