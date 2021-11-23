using System;
using System.Collections.Generic;

namespace RutujaLeetCode.Graphs
{
    public class GraphProblems
    {
        public GraphProblems ()
        {
        }


        /// <summary>
        /// https://leetcode.com/problems/find-center-of-star-graph/
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static int FindCenter (int [] [] edges)
        {
            // [[1,2] [2,3] [4,2]]
            //   0,1  1,1  2,1
            //  a1,b1 a2,b2
            //Compare first row with second row only, no need to loop till then end
            //whichever is the common among them thats the answer

            if (edges [0] [0] == edges [1] [0] || edges [0] [0] == edges [1] [1])
                return edges [0] [0];
            else
                return
                    edges [0] [1];
        }

        public LinkedList<int> [] adj;

        public int Findjudge (int n, int [] [] trust)
        {
            if (trust.Length == 0 && n == 1)
                return n;
            else if (trust.Length == 0)
                return -1;
            adj = new LinkedList<int> [n + 1];
            int findEmptyOne = -1;
            int locationofItem = -1;
            int emptyCount = 0;
            int foundOne = 0;
            for (int i = 1; i <= n; i++) {
                adj [i] = new LinkedList<int> ();
            }
            for (int i = 0; i < trust.Length; i++) {
                int v = trust [i] [0];
                int e = trust [i] [1];
                addEdge (v, e);
            }

            for (int i = 1; i <= n; i++) {
                if (adj [i].Count == 0) {
                    findEmptyOne = i;
                    emptyCount++;
                    locationofItem = i;
                }
            }
            if (emptyCount > 1)
                return -1;
            for (int i = 1; i <= n && i != locationofItem; i++) {
                foundOne = 0;
                foreach (int item in adj [i]) {
                    if (findEmptyOne == item) {
                        foundOne++;
                        break;
                    }
                }
                if (foundOne == 0)
                    return -1;
            }

            return findEmptyOne;
        }

        public void addEdge (int v, int e)
        {
            adj [v].AddLast (e);
        }
    }
}
