using System;

namespace LinkedListReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var list = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, null)))));
            sol.Print(sol.Reverse(list));

            Console.WriteLine();
            var list2 = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5, null)))));
            sol.Print(sol.Reverse(list2));
        }
    }

    class Solution
    {
        public Node ReverseOptimized(Node head)
        {
            var prev = (Node)null;
            var current = head;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }

        public Node Reverse(Node head)
        {
            var l = (Node)null;
            var m = head;
            var r = head.Next;

            m.Next = l;
            l = m;
            m = r;
            r = r.Next;

            while (r != null)
            {
                m.Next = l;
                l = m;
                m = r;
                r = r.Next;
            }
            m.Next = l;

            return m;
        }

        public void Print(Node head)
        {
            var current = new Node(head.Val,head.Next);
            while (current != null)
            {
                Console.Write(current.Val + ", ");
                current = current.Next;
            }
        }
    }

    public class Node
    {
        public Node(int val, Node next)
        {
            Val = val;
            Next = next;
        }
        public int Val { get; set; }
        public Node Next { get; set; }
    }
}
