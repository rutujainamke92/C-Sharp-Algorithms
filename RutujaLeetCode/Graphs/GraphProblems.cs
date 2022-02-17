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

                if (grid [0] [0] == 1 || grid [row - 1] [col - 1] == 1)  //All edges cases. Start and end should not be 1.
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


        Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>> ();

        public bool CanFinish (int numCourses, int [] [] prerequisites)
        {

            bool [] visited = new bool [numCourses];

            for (int i = 0; i < numCourses; i++) {
                preMap [i] = new List<int> ();
            }

            for (int i = 0; i < numCourses; i++) {
                preMap [prerequisites [i] [0]].Add (prerequisites [i] [1]);
            }

            for (int i = 0; i < numCourses; i++) {
                if (!dfs (i, visited))
                    return false;
            }
            return true;
        }

        private bool dfs (int course, bool [] visited)
        {
            if (visited [course]) return false;

            if (preMap [course] == null) return true;

            visited [course] = true;

            foreach (var pre in preMap [course]) {
                if (!dfs (pre, visited))
                    return false;
            }

            //            visited[course]=null;
            preMap [course].Clear ();
            return true;
        }

        public double [] CalcEquation (IList<IList<string>> equations, double [] values, IList<IList<string>> queries)
        {
            //step1. Build the graph from the Equation.

            var graph = new Dictionary<string, Dictionary<string, double>> ();

            for (int i = 0; i < equations.Count; i++) {
                var equation = equations [i];
                var numerator = equation [0];
                var denominator = equation [1];

                //create node in graph/dictionary if not present
                if (!graph.ContainsKey (numerator))
                    graph.Add (numerator, new Dictionary<string, double> ());
                if (!graph.ContainsKey (denominator))
                    graph.Add (denominator, new Dictionary<string, double> ());

                //Add both ways (2 way street)
                graph [numerator].Add (denominator, values [i]);

                graph [denominator].Add (numerator, 1 / values [i]);


            }

            //step2. evaluate each query by backtracking (DFS)
            double [] result = new double [queries.Count];

            for (int i = 0; i < queries.Count; i++) {
                var query = queries [i];
                var numer = query [0];
                var denom = query [1]; //denomerator

                if (!graph.ContainsKey (numer) || !graph.ContainsKey (denom)) //condition 1- if the node doesnt exist.
                    result [i] = -1.0;
                else if (numer == denom) //self loop
                    result [i] = 1;
                else {
                    //solve the equation using path search
                    var visited = new HashSet<string> ();
                    result [i] = BacktrackEvaluate (graph, numer, denom, 1, visited);
                }
            }

            return new double [0];
        }

        public double BacktrackEvaluate (Dictionary<string, Dictionary<string, double>> graph, string current, string target, double accProduct, HashSet<string> visited)
        {
            //add current node to visited array
            visited.Add (current);
            double result = -1.0;

            var neighbors = graph [current];
            if (neighbors.ContainsKey (target))
                result = accProduct * neighbors [target];
            else {
                foreach (var neighbor in neighbors) {
                    var nextnode = neighbor.Key;
                    var neighborValue = neighbor.Value;

                    //for current backtracking if node is aleady visited we continue
                    if (visited.Contains (nextnode))
                        continue;
                    //else we calculate prodcut of currNode's value and neighbour's value
                    //we pass that product down the line to complete backtracking until targetNode
                    result = BacktrackEvaluate (graph, nextnode, target, accProduct * neighborValue, visited);
                    //if we dont get -1.0 that mean we found the path so we should break the loop
                    //else continue with next neighbour
                    if (result == -1.0)
                        break;
                }
            }
            // 3. Unmark the visit, for next backtracking
            visited.Remove (current);
            return result;
        }

        //equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
        private int minimumCost = int.MaxValue;
        public int FindCheapestPrice (int n, int [] [] flights, int src, int dst, int k)
        {
            var graph = new Dictionary<int, Dictionary<int, int>> (n);
            var visited = new HashSet<int> ();  //Visited array fro data pruning.

            //create a graph out of given flights.
            //visited array also        

            for (int i = 0; i < flights.Length; i++) {
                int start = flights [i] [0];
                int end = flights [i] [1];
                int cost = flights [i] [2];
                if (graph.ContainsKey (start))
                    graph [start].Add (end, cost);
                else
                    graph.Add (start, new Dictionary<int, int> () { { end, cost } });
            }

            DFS (visited, graph, src, dst, k + 1, 0); //Make sure to send K+1 nodes.  

            return minimumCost == int.MaxValue ? -1 : minimumCost;
        }

        private void DFS (HashSet<int> visited, Dictionary<int, Dictionary<int, int>> graph, int src, int target, int K, int cost)
        {
            //Can add visited array here to improve pruning.
            //3 edges cases. k is already exhausted
            //Graph doesnot contain that node
            //Target acheived hence return back.

            if (K < 0)
                return;

            if (src == target) {
                minimumCost = cost;
                return;
            }
            if (!graph.ContainsKey (src) || visited.Contains(src)) return;

            visited.Add (src);

            foreach (var neighbor in graph [src]) {
                var newCost = cost + neighbor.Value;  //Very imp to not mix newcost with Cost.
                if (newCost > minimumCost)
                    continue;
                DFS (visited, graph, neighbor.Key, target, K - 1, newCost);
            }
            visited.Remove(src);
        }
    }
}
