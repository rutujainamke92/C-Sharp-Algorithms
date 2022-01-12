using System;
using System.Collections.Generic;


//test
namespace RutujaLeetCode.Tree
{
    public class TreeProblems
    {
        public TreeProblems ()
        {
        }


        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode (int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static int sum = 0;

        public static int RangeSumBST (TreeNode root, int low, int high)
        {
            range_Sum (root, low, high);
            return sum;
        }

        public static int range_Sum (TreeNode root, int low, int high)
        {
            if (root != null) {
                if (root.val >= low && root.val <= high) {
                    sum = root.val + sum;
                }
                if (root.left.val >= low) {
                    range_Sum (root.left, low, high);
                } else if (root.right.val <= high) {
                    range_Sum (root.right, low, high);
                }
            }
            return sum;
        }


        public static List<int> ans = new List<int> ();
        public IList<int> InorderTraversal (TreeNode root)
        {
            Inorder2 (root);
            return ans;
        }

        public static void Inorder2 (TreeNode root)
        {
            if (root == null)
                return;

            Inorder2 (root.left);
            ans.Add (root.val);
            Inorder2 (root.right);
        }      
    }
}
