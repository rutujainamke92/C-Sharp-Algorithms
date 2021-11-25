using System;
using System.Collections.Generic;

namespace RutujaLeetCode.Tree
{
    public class LevelOrderBindaryTree
    {

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node (int val = 0)
            {
                this.val = val;
            }
        };

        static Node root = null;

        static List<Node> q = new List<Node> ();

        // Function to create a node
        // with 'value' as the data
        // stored in it.
        // Both the children of this
        // new Node are initially null.
        public static Node newNode (int value)
        {
            Node n = new Node ();
            n.val = value;
            n.left = null;
            n.right = null;
            return n;
        }

        public static void insertValue (int value)
        {
            Node node = newNode (value);
            if (root == null)
                root = node;

            // The left child of the
            // current Node is used
            // if it is available.
            else if (q [0].left == null)
                q [0].left = node;

            // The right child of the current
            // Node is used if it is available.
            // Since the left child of this
            // node has already been used, the
            // Node is popped from the queue
            // after using its right child.
            else {
                q [0].right = node;
                q.RemoveAt (0);
            }

            // Whenever a new Node is added
            // to the tree, its address is
            // pushed into the queue. So that
            // its children Nodes can be used
            // later.
            q.Add (node);

        }

        // This function mainly calls
        // insertValue() for all array
        // elements. All calls use same
        // queue.
        public static Node createTree (int [] arr, int n)
        {
            for (int i = 0; i < n; i++)
                insertValue (arr [i]);
            return root;
        }


    }

}
