using System;
using System.Collections.Generic;

namespace _1_arrary_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s1 = new Stack<int>();

            var sol = new Solution();
            var lista = sol.AddTwoNumbers(
                new ListNode(2, new ListNode(4, new ListNode (3))), 
                new ListNode(5, new ListNode(6,new ListNode(4)))
            );
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int overflow = 0;
            ListNode head = new ListNode();
            ListNode current = head;
            while (l1 != null || l2 != null)
            {
                int v1 = l1 != null ? l1.val : 0;
                int v2 = l2 != null ? l2.val : 0;

                current.val = (v1 + v2 + overflow) % 10;
                overflow = (v1 + v2 + overflow) / 10;
                l1 = l1.next;
                l2 = l2.next;

                current.next = (l1 != null || l2 != null) ? new ListNode() : null;
                current = current.next;
            }
            if (overflow > 0)
                current.next = new ListNode(overflow);

            return head;
        }
    }
}
