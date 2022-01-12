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

        public static IList<IList<int>> AllPathsSourceTarget (int [] [] graph)
        {
            List<IList<int>> paths = new List<IList<int>> (); //store all paths from source to target 

            List<int> path = new List<int> ();  //store each unique path from source to target 

            //Use DFS all paths from 0 to n-1 node.            
            dfs (0, graph, path, paths);

            //Calc in DFS fashion go as deep until we reach target node.
            return paths;
        }
        public static void dfs (int node, int [] [] graph, List<int> path, List<IList<int>> paths)
        {
            path.Add (node);

            if (node == graph.Length - 1) { //check if this node is our targetNode.
                paths.Add (new List<int> (path));
                return;
            }

            int [] nextNodes = graph [node];
            foreach (int item in nextNodes) { //each nodes adjacnet nodes i.e. nextNodes
                //for each node - visit its adjacent nodes 
                dfs (item, graph, path, paths);

                //IMP //backtrack --remove the node added so we can traverse anopther path

                path.RemoveAt (path.Count - 1);
            }
        }

        public bool ValidPath (int n, int [] [] edges, int start, int end) //undirected graph hence visited array
        { //BFS 
            List<int> [] graph = new List<int> [n];
            for (int i = 0; i < n; i++) {
                graph [i] = new List<int> ();
            }
            foreach (var item in edges) {
                graph [item [0]].Add (item [1]);
                graph [item [1]].Add (item [1]);
            }


            bool [] visited = new bool [n];
            return bfs (graph, visited, start, end);
        }

        bool bfs (List<int> [] graph, bool [] visited, int start, int end)
        {
            Queue<int> que = new Queue<int> ();
            que.Enqueue (start);
            visited [start] = true;
            while (que.Count > 0) {

                var cur = que.Dequeue ();
                if (cur == end)
                    return true;

                var nextNodes = graph [cur];
                foreach (var item in nextNodes) {

                    if (!visited [item]) {
                        visited [item] = true;
                        que.Enqueue (item);
                    }
                }
            }
            return false;
        }


        public class Solution
        {
            public int ShortestPathBinaryMatrix (int [] [] grid)
            {
                int row = grid.Length;
                int col = grid [0].Length;
                int level = 0;              //keep track of our shortestpath i.e. the level.

                if (grid.Length == 0 || grid == null)
                    return 0;

                if(grid [0] [0] == 1 || grid [row - 1] [col - 1] == 1)  //All edges cases. Start and end should not be 1.
                  return -1;                   

                Queue<int []> qu = new Queue<int []> ();
                qu.Enqueue (new int [] { 0, 0 });
                //Put first element in the Q  

                int [] [] dirs = new int [] [] {
                    new int[]{ 1, 0 },new int[] { 0, 1 },
                    new int[]{ -1, 0 },new int[] { 0, -1 },
                    new int[] { -1, -1 },new int[] { 1, 1 } };  //Can go 8 directional. need directions array.

                while (qu.Count > 0) {
                    int size = qu.Count;
                    level++;

                    for (int i = 0; i < size; i++) {
                        int [] cur = qu.Dequeue ();
                        int curX = cur [0];
                        int curY = cur [1];

                        if (curX == row - 1 && curY == col - 1) //that means we reached our end. hence return.
                            return level;

                        foreach (var dir in dirs) {
                            int x = curX + dir [0];
                            int y = curY + dir [1];

                            if (x < 0 || y < 0 || x > row - 1 || y > row - 1 || grid [x] [y] == 1)
                                continue;
                            else {
                                //Contains 0
                                qu.Enqueue (new int [] { x, y });
                                grid [x] [y] = 1;
                            }
                        }

                    }
                }

                return -1;
            }
        }

        //Start from 0,0
        //Mopve all 8 directions. Check if this is 0 or not. 
        //Find all neighbors and stroe all 0's in  Q
        //Pop from q then move that way and push its neighbors in Q
        //After we poll increment level; 

    }
}
