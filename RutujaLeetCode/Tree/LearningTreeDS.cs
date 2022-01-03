using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RutujaLeetCode.Tree
{
    // Definition for a binary tree node.
    public class LearningTree
    {
        public class Node
        {
            public int val;
            public Node left, right;

            public Node (int item)
            {
                val = item;
                left = right = null;
            }
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left = null;
            public TreeNode right = null;
            public TreeNode (int val = 0)
            {
                this.val = val;
            }
        }
        //public Node root = new Node ();
        static TreeNode root = null;

        static List<TreeNode> q = new List<TreeNode> ();

        // Function to create a node
        // with 'value' as the data
        // stored in it.
        // Both the children of this
        // new Node are initially null.
        public static TreeNode newNode (int value)
        {
            TreeNode n = new TreeNode ();
            n.val = value;
            n.left = null;
            n.right = null;
            return n;
        }

        public static void insertValue (int value)
        {
            TreeNode node = newNode (value);
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
        public static TreeNode createTree (int [] arr, int n)
        {
            for (int i = 0; i < n; i++)
                insertValue (arr [i]);
            return root;
        }


        public void IntersertionUsed (TreeNode givenNode, int insert)
        {
            var curr = new TreeNode (insert);

            if (givenNode.left == null)
                givenNode.left = curr;

            else
                IntersertionUsed (givenNode.left, insert);

            if (givenNode.right == null)
                givenNode.right = curr;
            else
                IntersertionUsed (givenNode.right, insert);

        }


        public void InsertVal (TreeNode root, int insert)
        {
            if (root == null) {
                root.val = insert;
            } else {
                InserNode2 (root, insert);
            }
        }
        public void InserNode2 (TreeNode givenNode, int insert)
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

        public TreeNode insertDFS (int [] keys)
        {
            TreeNode root = new TreeNode ();
            foreach (int key in keys) {
                InsertDfs (root, key);
            }
            return root;
        }
        public void InsertDfs (TreeNode node, int val)
        {
            if (node.val > val) {
                if (node.left == null)
                    node.left = new TreeNode (val);
                else
                    InsertDfs (node.left, val);
            } else {
                if (node.right == null)
                    node.right = new TreeNode (val);
                else
                    InsertDfs (node.right, val);
            }
        }

        //Inorder
        public void DisplayTree (TreeNode root)
        {
            if (root == null) return;

            DisplayTree (root.left);
            System.Console.Write (root.val + " ");
            DisplayTree (root.right);
        }


        // Function to check the given key exist or not
        static bool iterativeSearch (TreeNode root, int key)
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
        public static int MaxDepth (TreeNode root)
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
        public bool IsSameTree (TreeNode p, TreeNode q)
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

        public void preOrderStore (TreeNode root, List<int> ans)
        {
            if (root == null) {
                ans.Add (0);
                return;
            }
            ans.Add (root.val);
            preOrderStore (root.left, ans);
            preOrderStore (root.right, ans);
        }

        public void postOrderStore (TreeNode root, List<int> ans)
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
        public IList<IList<int>> LevelOrder (TreeNode node)
        {
            IList<IList<int>> result = new List<IList<int>> ();
            Queue<TreeNode> q = new Queue<TreeNode> ();
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
        public bool IsSymmetric (TreeNode root)
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
        public static int FindClosestValueInBst (TreeNode tree, int target)
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
        public static bool IsIdentical (TreeNode x, TreeNode y)
        {
            if (x == null && y == null)
                return true;
            return IsIdenticalPre (x, y);
        }

        public static bool IsIdenticalPre (TreeNode x, TreeNode y)
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

        public static int FindLevelofTree (TreeNode root, int level)
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

        public TreeNode insertIntoBST (TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode (val);

            DFS (root, val);

            return root;
        }

        private void DFS (TreeNode node, int val)
        {
            if (node.val > val) {
                if (node.left == null)
                    node.left = new TreeNode (val);
                else
                    DFS (node.left, val);
            } else {
                if (node.right == null)
                    node.right = new TreeNode (val);
                else
                    DFS (node.right, val);
            }
        }


        ///AlgoMonster + LC
        ///https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
        public static IList<IList<int>> ZigzagLevelOrder (TreeNode root)
        {
            if (root == null)
                return new List<IList<int>> ();
            List<IList<int>> result = new List<IList<int>> ();
            Queue<TreeNode> qu = new Queue<TreeNode> ();
            int count = 0;
            qu.Enqueue (root);

            while (qu.Count > 0) {
                List<int> zigzag = new List<int> ();

                int size = qu.Count;

                while (size > 0) {
                    var current = qu.Dequeue ();
                    zigzag.Add (current.val);
                    if (current.left != null)
                        qu.Enqueue (current.left);
                    if (current.right != null)
                        qu.Enqueue (current.right);

                    count++;
                    size--;

                }
                if (result.Count % 2 == 1)
                    zigzag.Reverse ();
                result.Add (zigzag);
            }
            return result;

        }

        //VV IMP FB, GOOGLE, ALL COMPANIES
        //https://leetcode.com/problems/binary-tree-right-side-view/
        public static IList<int> RightSideView (TreeNode root)
        {
            List<int> res = new List<int> ();

            if (root == null)
                return res;

            Queue<TreeNode> qu = new Queue<TreeNode> ();
            qu.Enqueue (root);

            while (qu.Count > 0) {
                int size = qu.Count ();
                res.Add (qu.Peek ().val);  // only append the first node we encounter since it's the rightmost

                while (size > 0) {
                    var current = qu.Dequeue (); //Check code on Leetcode.It might have changed
                    if (current.right != null)
                        qu.Enqueue (current.right);
                    if (current.left != null)
                        qu.Enqueue (current.left);
                    size--;
                }
            }
            if (qu.Count > 0)
                res.Add (qu.Peek ().val);

            return res;


        }

        /// <summary>
        /// https://leetcode.com/problems/average-of-levels-in-binary-tree/
        /// </summary>
        public static IList<double> AverageOfLevels (TreeNode root)
        {
            //Using BFS because level wise avg 
            if (root == null)
                return new List<double> ();

            Queue<TreeNode> qu = new Queue<TreeNode> ();
            List<double> avgList = new List<double> ();
            qu.Enqueue (root);
            double avgSum = 0;
            while (qu.Count > 0) {
                int size = qu.Count;
                int numOfNodes = qu.Count;
                avgSum = 0;
                while (size > 0) {
                    var cur = qu.Dequeue ();
                    avgSum = avgSum + cur.val;

                    if (cur.left != null)
                        qu.Enqueue (cur.left);

                    if (cur.left != null)
                        qu.Enqueue (cur.right);
                    size--;
                }

                avgList.Add (avgSum / numOfNodes);
            }

            return avgList;
        }

        public static IList<int> DFSInOrderTraversalwithStack (Node root)
        {
            List<int> res = new List<int> ();

            if (root == null)
                return res;
            Stack<Node> stk = new Stack<Node> ();
            var cur = root;
            while (stk.Count > 0 || cur != null) {

                while (cur != null) {
                    stk.Push (cur);
                    cur = cur.left;
                }
                cur = stk.Pop ();
                res.Add (cur.val);
                cur = cur.right;

            }
            return res;
        }


        TreeNode copy = new TreeNode ();
        TreeNode pointToHead = null;  //Pointing to head and return that value in the end

        public TreeNode IncreasingBST (TreeNode root)
        {
            pointToHead = copy;  //Pointing to head and return that value in the end


            if (root == null)
                return null;
            inOrder (root);
            return pointToHead.right;
        }

        public void inOrder (TreeNode cur)
        {
            if (cur == null)
                return;

            inOrder (cur.left);  //call recursively.

            copy.left = null;  //imp to set left as null.
            copy.right = cur; //Add curr value to each new copy node we create.
            copy = copy.right;    ///increase pointers.

            inOrder (cur.right);
        }


        List<TreeNode> pPath;
        List<TreeNode> qPath;
        public TreeNode LowestCommonAncestor (TreeNode root, TreeNode p, TreeNode q)
        {
            pPath = new List<TreeNode> ();
            qPath = new List<TreeNode> ();

            find (root, p.val, pPath);
            find (root, q.val, qPath);

            int i = pPath.Count - 1, j = qPath.Count - 1;
            while (i >= 0 && j >= 0 && pPath [i] == qPath [j]) {
                i--; j--;
            }

            i++; j++; //since i and j will be at pointer where the previous i & j were a match.

            return pPath [i]; //or qPath[j] both will be same LCA

        }

        public static bool find (TreeNode root, int data, List<TreeNode> path)
        {
            if (root == null)
                return false;
            if (root.val == data) {
                path.Add (root);
                return true;
            }

            bool leftchild = find (root.left, data, path);
            if (leftchild) {
                path.Add (root);
                return true;
            }

            bool rightchild = find (root.right, data, path);
            if (rightchild) {
                path.Add (root);
                return true;
            }

            return false;
        }

        List<int> setList;

        public int FindSecondMinimumValue (TreeNode root)
        {
            setList = new List<int> ();
            if (setList.Count >= 1)
                return setList [1];
            else return -1;
        }

        public void inOrder2 (TreeNode root)
        {
            if (root == null)
                return;

            if (!setList.Contains (root.val)) {
                setList.Add (root.val);
            }
            inOrder (root.left);
            inOrder (root.right);
        }

        Queue<TreeNode> que = new Queue<TreeNode> ();
        List<IList<int>> ans = new List<IList<int>> ();
        public IList<IList<int>> LevelOrderLC (TreeNode root)
        {
            que.Enqueue (root);
            while (que.Count > 0) {
                int size = que.Count;
                var temp = new List<int> ();

                while (size > 0) {
                    var cur = que.Dequeue ();
                    temp.Add (cur.val);
                    if (cur.left != null) {
                        que.Enqueue (cur.left);
                    }
                    if (cur.right != null) {
                        que.Enqueue (cur.right);
                    }
                }
                size--;
                ans.Add (temp);
            }
            return ans;
        }

        List<IList<int>> result = new List<IList<int>> ();
        public IList<IList<int>> LevelOrderRecursive (TreeNode root)
        {
            if (root == null)
                return result;
            int level = 0;
            helper (root, level);
            return result;
        }
        public void helper (TreeNode cur, int level)
        {
            if (cur == null)
                return;
            if (result.Count != level)
                result.ElementAt (level).Add (cur.val);
            else
                result.ElementAt (level).Add (cur.val);

            if (cur.left != null)
                helper (cur.left, level + 1);
            if (cur.right != null)
                helper (cur.right, level + 1);

        }

        //HARD LC
        //https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
        // Encodes a tree to a single string.
        StringBuilder sb = new StringBuilder ();
        public string serialize (TreeNode root)
        {
            if (root == null) {
                sb.Append ("#" + ",");
                return sb.ToString ();
            }
            sb.Append (root.val + ",");
            serialize (root.left);
            serialize (root.right);
            return sb.ToString ();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize (string data)
        {
            Queue<string> qSt = new Queue<string> ();
            foreach (var item in data) {
                if (item == ',')
                    continue;
                qSt.Enqueue (item.ToString ());
            }
            return deserializeHelper (qSt);
        }

        public TreeNode deserializeHelper (Queue<string> que)
        {
            TreeNode treeNode = null;
            if (que.Count == 0)
                return treeNode;
            string node = que.Dequeue ();
            if (node == "#") return null;
            treeNode = new TreeNode (int.Parse (node));
            treeNode.left = deserializeHelper (que);
            treeNode.right = deserializeHelper (que);
            return treeNode;
        }

        //Queue<Node> quT = new Queue<Node> ();
        //public Node Connect (Node root)
        //{
        //    if (root == null)
        //        return null;
        //    quT.Enqueue (root);
        //    while(quT.Count>0) {
        //        int size = quT.Count;

        //        while(size>0) {
        //            var cur = quT.Dequeue ();
        //            if (quT.Peek () != null)
        //                cur.next = quT.Peek ();
        //            else
        //                cur.next = null;
        //            size--;

        //            if (cur.left != null)
        //                quT.Enqueue (cur.left);
        //            if (cur.right != null)
        //                quT.Enqueue (cur.right);
        //            size--;
        //        }

        //    }
        //    return root;
        //}

        TreeNode node = null;
        public TreeNode SearchBST (TreeNode root, int val)
        {
            node = root;
            if (node == null || node.val == val)
                return node;

            if (val < node.val)
                return SearchBST (node.left, val);

            else//No need to chec if val>node.val its implied bydefault. hence directly calling right subtree;
                return SearchBST (node.right, val);
        }
    }

}

