using System;
using System.Collections.Generic;
namespace RutujaLeetCode.LinkedListSums
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode (int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    /// <summary>
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// Merge two sorted linked lists and return it as a sorted list.
    /// The list should be made by splicing together the nodes of the first two lists.
    /// </summary>
    public class LinkedListSums
    {

        public static ListNode MergeTwoLists (ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode (0);
            ListNode curr = dummy;          

            while (l1!=null || l2!=null) {
                if((l2==null) ||(l1!=null && l2.val>=l1.val)) {
                    curr.next = l1;
                    l1 = l1.next;
                } else {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;
            }

            return dummy.next;
        }
    }
}