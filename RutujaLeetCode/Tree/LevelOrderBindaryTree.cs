using System;
using System.Collections.Generic;
using System.Linq;

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

        public static int HeightofTree (Node node)
        {
            int height = 0;
            if (node == null)
                return 0;


            else {

                Queue<Node> q = new Queue<Node> ();
                q.Enqueue (node);

                while (q.Count > 0) {
                    int count = q.Count ();

                    height++;

                    while (count > 0) {
                        Node current = q.Peek ();
                        q.Dequeue ();
                        if (current.left != null)
                            q.Enqueue (current.left);
                        if (current.right != null)
                            q.Enqueue (current.right);

                        count--;
                    }
                }


            }
            return height;
        }


        public int MinDepth (Node root)
        {
            if (root != null) {
                return CalcMinDepth (root, 1);
            } else
                return 0;

        }
        public int CalcMinDepth (Node node, int height)
        {
            if (node == null)
                return height;
            else
                return Math.Min (CalcMinDepth (node.left, 1 + height), CalcMinDepth (node.right, 1 + height));
        }

        public bool IsBalanced (Node root)
        {
            if (root == null || (root.right == null && root.left == null))
                return true;

            if (Math.Abs (HeightofTree (root.left) - HeightofTree (root.right)) > 1)
                return false;
            else
                return IsBalanced (root.left) && IsBalanced (root.right);
        }
      
    }

}
