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

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node (int _val)
        {
            val = _val;
            next = null;
            random = null;
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
        public static Node Add (int v, Node l1, int randomValue)
        {
            Node curr = l1;
            Node temp = new Node (v);
            while (curr.next != null) {
                curr = curr.next;
            }
            curr.next = temp;
            curr.random = new Node (randomValue);
            return l1;
        }

        public static void Add (int v, ListNode l1)
        {
            ListNode curr = l1;
            ListNode temp = new ListNode (v);
            while (curr.next != null) {
                curr = curr.next;
            }
            curr.next = temp;
        }
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
                int now = st.Pop ();
                if (now != curr2.val) {
                    return false;
                }
                curr2 = curr2.next;
            }
            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/linked-list-cycle/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool HasCycle (ListNode head)
        {
            if (head.next == null || head == null)
                return false;
            ListNode curr = head;
            Dictionary<int, int> dict = new Dictionary<int, int> ();

            while (curr != null) {
                if (dict.ContainsKey (curr.val))
                    return false;
                else {
                    if (curr.next != null)
                        dict.Add (curr.val, curr.next.val);
                    else
                        dict.Add (curr.val, -1);
                }
                curr = curr.next;
            }
            return true;
        }
        /// <summary>
        /// https://leetcode.com/problems/copy-list-with-random-pointer/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Node CopyRandomList (Node head)
        {
            //Found difficult to create logic for first while loop.
            //Even after watching anuj bhaiyya video.

            Node curr = head;         //1. while loop for linking new copy to existing. create zigzag route 
            while (curr != null) {
                Node copy = new Node (curr.val);
                Node temp = curr.next;
                curr.next = copy;
                curr.next.next = temp;
                curr = temp;
            }
            curr = head;


            //2. while loop to random pointer links
            while (curr != null) {
                if (curr.next != null) {
                    curr.next.random = (curr.random != null) ? curr.random.next : null;
                }

                curr = curr.next.next;
            }
            curr = head.next;
            //3. remove links and separate two listnodes.

            Node nextptr = curr;
            Node orig = head;
            while (orig != null && nextptr.next != null) {
                orig.next = orig.next.next;
                nextptr.next = nextptr.next.next;
                orig = orig.next;
                nextptr = nextptr.next;
            }

            return curr;

        }

        public static Node CopyRandomList2 (Node head)
        {
            //Found difficult to create logic for first while loop.
            //Even after watching anuj bhaiyya video.
            Dictionary<Node, Node> dict = new Dictionary<Node, Node> ();
            Node curr = head;
            while (curr != null) {
                dict.Add (curr, new Node (curr.val)); //create a dict with new Node(curr.val)
                curr = curr.next;
            }
            curr = head;
            Node copy = new Node (curr.val);
            Node copyHead = copy;
            foreach (var item in dict) {

                Node temp = item.Key;
                copy.val = temp.val;
                copy.next = temp.next;
                copy.random = item.Value;
                copy = copy.next;
            }
            return copyHead;

        }

        public static ListNode SwapPairs (ListNode head)
        {
            ListNode dummy = new ListNode (-1);
            dummy.next = head;

            ListNode prev = dummy;

            while ((head != null) && (head.next != null)) {
                //Node to be swapped
                ListNode first = head;
                ListNode second = head.next;

                //swapping
                prev.next = second;
                first.next = second.next;
                second.next = first;

                //Reinitializing head and pre for next swap/iteration
                prev = first;
                head = first.next;
            }

            return dummy.next;
        }

        public static ListNode MergeTwoLists2 (ListNode list1, ListNode list2)
        {
            ListNode prev = new ListNode ();
            prev.next = list1;
            while (list1 != null || list2 != null) {
                var temp = prev.next;

                if (list1 != null && list1.val >= list2.val) {
                    list1.next = list2;
                    list2 = list2.next;
                    list1.next.next = temp;
                } else if (list2 != null && list1.next == null) {
                    list1.next = list2;
                    list2 = list2.next;
                    list1 = list1.next;

                } else
                    list1 = list1.next;
            }
            return prev.next;

        }
    }

    public class LRUCache
    { //Requirement -->The functions get and put must each run in O(1) average time complexity.
      //DS- Doubly lL + Dictionary

        /*
       lruList: 
       1. Most recent used cache will be added in the head of the LinkedList.
       2. Use LinkedListNode to add/remove element to achieve O(1) time complexity.
       3. LinkedList<T>.Last returns the last LinkedListNode<T>.
   */
        int capacity = 0;
        LinkedList<int[]> doubleLink = new LinkedList<int[]> ();   //LL is nothing but doubly linkd list in C#
        Dictionary<int, LinkedListNode<int []>> dict = new Dictionary<int, LinkedListNode<int []>> (); //Represents a node in a LinkedList<T>. Node of type doubly LL.
        public LRUCache (int capacity)
        {
            this.capacity = capacity;
        }

        public int Get (int key)
        {
            if(!dict.ContainsKey(key)) {
                return -1;
            }

            //make this key first in list.
            //Reorder(dict[key]);
            return dict [key].Value[1];  //Key=0 Value=1, hence Value[1]
        }

        public void Put (int key, int value)
        {
            if (dict.ContainsKey (key))
                dict [key].Value[1] = value;

            else {
                if(dict.Count == this.capacity) {
                    {
                        dict.Remove (doubleLink.Last.Value [0]);
                        doubleLink.RemoveLast (); //Removes it from our LL too. Inbuilt Remove last func. 
                    }

                    dict.Add (key, new LinkedListNode<int []> (new int [] { key, value }));
                }
            }
            Reorder (dict [key]);
        }

        private void Reorder (LinkedListNode<int[]> node) //makes element afirst element, to show it was recently used/
        {
            if (node.Previous != null)  //i.e. its not the first element
                doubleLink.Remove (node);

            if (doubleLink.First != node) //Make this node start at the list
                doubleLink.AddFirst (node); //Use of In built add first operation. 
        }

        public ListNode AddTwoNumbers (ListNode l1, ListNode l2)
        {
            int first = 99;
            int sec = 1;
            int sum = first + sec;

            ListNode ans = new ListNode ();
            var start = new ListNode ();
            start.next = ans;
            start = start.next;
            while (sum > 0) {
                start.val = sum % 10;
                start = start.next;
                sum = sum / 10;
            }

            return ans;
        }

        private int convertNum (ListNode l1)
        {
            var first = l1;
            int firstNum = 0;
            while (first.next != null) {
                firstNum = firstNum * 10 + first.val;
            }
            return firstNum;
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    

}