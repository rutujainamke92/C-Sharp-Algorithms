using System;
using System.Collections.Generic;

namespace RutujaLeetCode.Graphs
{
    public class Graph
    {
        //Create Array of linked List
        //For example each Vertix in array will have values of all its edges
        //[0]-->[2]-->[3]
        //[1]-->[5]-->[6]
        //[2]-->[4]-->[6]
        public LinkedList<int> [] adj;

        public Graph (int v)
        {
            adj = new LinkedList<int> [v];
            for (int i = 0; i < v; i++) {
                adj [i] = new LinkedList<int> ();
            }
        }

        public void addEdge (int source, int dest)
        {
            adj [source].AddLast (dest);
            adj [dest].AddLast (source);
        }

        public void mainMethod ()
        {
            Graph g = new Graph (6);
            addEdge (0, 1);
            addEdge (1, 2);
            addEdge (2, 3);
            addEdge (2, 4);
            addEdge (3, 4);
            addEdge (0, 4);
            bfs (0, 3);

        }

        public int bfs (int src, int dest)
        {
            //create q
            //loop while q is empty
            //check if val in q is visited or not
            //if visited skip
            //if not visited add to queue
            //

            bool [] visited = new bool [adj.Length];
            Queue<int> q = new Queue<int> ();
            q.Enqueue (src);
            int dist = 0;
            visited [src] = true;
            while (q.Count > 0) {
                int curr = q.Dequeue ();
                if (curr == dest) {
                    break;
                }
                if (!visited [curr]) {
                    visited [curr] = true;
                    Console.WriteLine (curr + "-->");
                    dist++;
                }
                foreach (int i in adj [src]) {
                    if (!visited [i]) {
                        q.Enqueue (i);
                    }

                }

            }
            Console.WriteLine (dist);
            return dist;

        }
    }
}