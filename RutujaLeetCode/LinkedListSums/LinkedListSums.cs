using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

    /*
     Add Value in ListNode
     ListNode l1 = new ListNode (1);
      Add (1);
      Add (1);
      Add (2);
      void Add (int v)
      {
          ListNode curr = l1;
          ListNode temp = new ListNode (v);
          while (curr.next != null) {
              curr = curr.next;
          }
          curr.next = temp;
      }
    */

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

            while (l1 != null || l2 != null) {
                if ((l2 == null) || (l1 != null && l2.val >= l1.val)) {
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

        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode DeleteDuplicates (ListNode head)
        {
            ListNode ptr1 = head;

            while (ptr1.next != null) {
                if (ptr1.val == ptr1.next.val) {
                    ptr1.next = ptr1.next.next;
                } else {
                    ptr1 = ptr1.next;
                }
            }
            return head;

            //DO READ!
            //Another Option to solve this with two pointers
            /*def deleteDuplicates(self, head):
                 """
                 :type head: ListNode
                 :rtype: ListNode
                 """
                 if head == None:
                     return head

                 current = head.next
                 prev = head

                 while current != None:
                     if current.val == prev.val:
                         prev.next = current.next
                         current = current.next
                     else:
                         current = current.next
                         prev = prev.next

                 return head*/
        }

        /// <summary>
        /// https://leetcode.com/problems/middle-of-the-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode (ListNode head)
        {
            ListNode ptr1 = head;
            ListNode ptr2;
            //Check all edge cases.
            if (ptr1.next.next != null) {
                ptr2 = ptr1.next.next;
            } else if (ptr1.next != null) {
                return ptr1.next;
            } else {
                return ptr1;
            }
            while (ptr2.next.next != null) {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next.next;
            }
            if (ptr2.next != null)
                return ptr1.next;
            else
                return ptr1.next;
        }

        /// <summary>
        /// https://leetcode.com/problems/move-zeroes/
        /// </summary>
        /// <param name="nums"></param>
        public static void MoveZeroes (int [] nums)
        {
            //My Code: but less optimal   
            int n = nums.Length;
            int right = 1;
            int temp = -1;

            for (int left = 0; left < n && right < n; left++, right++) {
                if (nums [left] == 0) {
                    while (nums [right] == 0 && right < n - 1)
                        right++;
                    temp = nums [right];
                    nums [right] = nums [left];
                    nums [left] = temp;
                }
            }
            //The above soln uses O(n2) - time complexity 

            //Below soln uses only O(n) - time complexity - so its better

            /*  int current = 0;

             for (int i = 0; i < nums.Length; ++i)
                 if (nums[i] != 0)
                     nums[current++] = nums[i];

             for (int i = current; i < nums.Length; ++i)
                 nums[i] = 0;
                 */
        }

        /// <summary>
        /// https://leetcode.com/problems/palindrome-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome (ListNode head)
        {
            ListNode curr = head;
            Stack<int> st = new Stack<int> ();
            while (curr != null) {
                st.Push (curr.val);
                curr = curr.next;
            }

            ListNode curr2 = head;
            while (st != null) {
                int now = st.Pop();
                if (now != curr2.val) {
                    return false;
                }
                curr2 = curr2.next;
            }
            return true;
        }
    }
}