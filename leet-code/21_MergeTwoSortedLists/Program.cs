using System;
using System.Text;

namespace _21_MergeTwoSortedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solution();
            var l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            Console.WriteLine(l1);
            Console.WriteLine(l2);

            Console.WriteLine("1>" + solver.MergeTwoLists(l1, l2));
            Console.WriteLine("2>" + solver.MergeTwoLists(null, l2));
            Console.WriteLine("3>" + solver.MergeTwoLists(null, null));
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

            public override string ToString()
            {
                var sb = new StringBuilder();
                ListNode p = this;
                while (p != null)
                {
                    sb.Append(p.val).Append("->");
                    p = p.next;
                }
                return sb.ToString();
            }
        }
        public class Solution
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                ListNode head, ch, p1, p2;
                p1 = list1;
                p2 = list2;

                if (isNextFromOne(p1, p2))
                {
                    head = new ListNode(p1.val);
                    p1 = p1?.next;
                }
                else
                {
                    head = p2 != null ? new ListNode(p2.val) : null;
                    p2 = p2?.next;
                }
                ch = head;

                while (p1 != null || p2 != null)
                {
                    if (isNextFromOne(p1, p2))
                    {
                        ch.next = new ListNode(p1.val);
                        p1 = p1?.next;
                    }
                    else
                    {
                        ch.next = new ListNode(p2.val);
                        p2 = p2?.next;
                    }
                    ch = ch.next;
                }

                return head;
            }

            bool isNextFromOne(ListNode list1, ListNode list2)
            {
                if (list1 == null) return false;
                else if (list2 == null) return true;
                else
                {
                    return list1.val < list2.val;
                }
            }
        }
    }
}