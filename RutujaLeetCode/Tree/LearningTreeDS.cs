using System;
using System.Collections.Generic;

namespace RutujaLeetCode.Tree
{
    // Definition for a binary tree node.
    public class LearningTree
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
        }
        //public Node root = new Node ();
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

        public void InsertVal (Node root, int insert)
        {
            if (root == null) {
                root.val = insert;
            } else {
                InserNode2 (root, insert);
            }
        }
        public void InserNode2 (Node givenNode, int insert)
        {
            if (insert <= givenNode.val) {
                if (givenNode.left == null)
                    givenNode.left.val = insert;
                else
                    InserNode2 (givenNode.left, insert);
            }

            if (insert >= givenNode.val) {
                if (givenNode.right == null)
                    givenNode.right.val = insert;
                else
                    InserNode2 (givenNode.right, insert);
            }
        }

        public Node insertDFS (int [] keys)
        {
            Node root = new Node ();
            foreach (int key in keys) {
                InsertDfs (root, key);
            }
            return root;
        }
        public void InsertDfs (Node node, int val)
        {
            if (node.val > val) {
                if (node.left == null)
                    node.left = new Node (val);
                else
                    InsertDfs (node.left, val);
            } else {
                if (node.right == null)
                    node.right = new Node (val);
                else
                    InsertDfs (node.right, val);
            }
        }

        //Inorder
        public void DisplayTree (Node root)
        {
            if (root == null) return;

            DisplayTree (root.left);
            System.Console.Write (root.val + " ");
            DisplayTree (root.right);
        }


        // Function to check the given key exist or not
        static bool iterativeSearch (Node root, int key)
        {
            // Traverse until root reaches to dead end
            while (root != null) {
                // pass right subtree as new tree
                if (key > root.val)
                    root = root.right;

                // pass left subtree as new tree
                else if (key < root.val)
                    root = root.left;
                else
                    return true; // if the key is found return 1
            }
            return false;
        }

        /// <summary>
        /// Leetcode --> https://leetcode.com/problems/maximum-depth-of-binary-tree/
        /// ASKED BY GOOGLEE, AMAZON, APPLE, LINKEDIN, YAHOO
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepth (Node root)
        {
            int dist = 0;
            while (root != null) {
                if (root.left == null && root.right == null) {
                    dist++;
                    continue;
                }

                if (root.left != null)
                    root = root.left;

                else root = root.right;
            }
            return dist;
        }

        /// <summary>
        /// LeetCode--> https://leetcode.com/problems/same-tree/
        /// </summary>
        public bool IsSameTree (Node p, Node q)
        {
            List<int> treeA = new List<int> ();
            List<int> treeB = new List<int> ();
            preOrderStore (p, treeA);
            preOrderStore (q, treeB);
            bool ans = true;
            if (treeA.Count == treeB.Count) {
                for (int i = 0; i < treeA.Count; i++) {
                    if (treeA [i] == treeB [i])
                        continue;
                    else
                        return false;
                }
            } else return false;
            return ans;
        }

        public void preOrderStore (Node root, List<int> ans)
        {
            if (root == null) {
                ans.Add (0);
                return;
            }
            ans.Add (root.val);
            preOrderStore (root.left, ans);
            preOrderStore (root.right, ans);
        }

        public void postOrderStore (Node root, List<int> ans)
        {
            if (root == null) {
                ans.Add (0);
                return;
            }

            postOrderStore (root.left, ans);
            postOrderStore (root.right, ans);
            ans.Add (root.val);

        }


        /// <summary>
        /// https://leetcode.com/problems/binary-tree-level-order-traversal/
        /// MEDIUM PROBLEM
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder (Node node)
        {
            IList<IList<int>> result = new List<IList<int>> ();
            Queue<Node> q = new Queue<Node> ();
            if (node == null) {
                return result;
            }

            q.Enqueue (node);

            while (q.Count > 0) {
                int size = q.Count;
                IList<int> preOrderTraversal = new List<int> ();
                while (size != 0) {
                    var current = q.Dequeue ();

                    preOrderTraversal.Add (current.val);

                    if (current.left != null) {
                        q.Enqueue (current.left);
                    }

                    if (current.right != null) {
                        q.Enqueue (current.right);
                    }
                    size--;

                }
                result.Add (preOrderTraversal);
            }
            return result;
        }

        /// <summary>
        /// https://leetcode.com/problems/symmetric-tree/
        /// </summary>
        /// <param name="root"></param>
        public bool IsSymmetric (Node root)
        {
            List<int> treeA = new List<int> ();
            List<int> treeB = new List<int> ();


            if (root.left == null && root.right == null)
                return true;

            preOrderStore (root.left, treeA);
            postOrderStore (root.right, treeB);

            //Reverse Right Subtree
            treeB.Reverse ();

            if (treeA.Count == treeB.Count) {
                for (int i = 0; i < treeA.Count; i++) {
                    if (treeA [i] != treeB [i])
                        return false;

                }
            } else return false;
            return true;
        }

        //Algo Expert Probelm easy
        /// <summary>
        /// https://www.algoexpert.io/questions/Find%20Closest%20Value%20In%20BST
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int FindClosestValueInBst (Node tree, int target)
        {
            // Write your code here.
            int ans = tree.val;
            if (tree.val == target) {
                return tree.val;
            } else {
                while (tree != null) {
                    int difference = Math.Abs (ans - target);
                    if (target < tree.val && tree.left != null) {
                        tree = tree.left;
                        int diff = Math.Abs (tree.val - target);
                        if (difference > diff)
                            ans = tree.val;
                    } else if (target > tree.val && tree.right != null) {
                        tree = tree.right;
                        int diff = Math.Abs (tree.val - target);
                        if (difference > diff)
                            ans = tree.val;
                    }
                 //added this code
                 //if value is equal to node.value for example target is 15
                 //then just break and return valu
                 else {
                        break;
                    }
                }
            }

            return ans;
        }


        //Tech delight practise
        ///If two Trees are identitcal
        /////Find levels of trees
        ///if levels and number of nodes match then True else false
        public static bool IsIdentical (Node x, Node y)
        {
            if (x == null && y == null)
                return true;
            return IsIdenticalPre (x, y);
        }

        public static bool IsIdenticalPre (Node x, Node y)
        {
            bool boolVal = true;
            int first = x.val;
            int sec = y.val;
            if (x != null && y != null) {
                if (first == sec) {
                    IsIdenticalPre (x.left, y.left);
                    IsIdenticalPre (x.right, y.right);

                }
            } else
                boolVal = false;
            return boolVal;
        }

        public static int FindLevelofTree (Node root, int level)
        {
            while (root != null && (root.left != null || root.right != null)) {
                level++;
                if (root.left != null)
                    root = root.left;
                else if (root.right != null)
                    root = root.right;
            }

            return level;

        }

        public Node insertIntoBST (Node root, int val)
        {
            if (root == null)
                return new Node (val);

            DFS (root, val);

            return root;
        }

        private void DFS (Node node, int val)
        {
            if (node.val > val) {
                if (node.left == null)
                    node.left = new Node (val);
                else
                    DFS (node.left, val);
            } else {
                if (node.right == null)
                    node.right = new Node (val);
                else
                    DFS (node.right, val);
            }
        }
    }
}
