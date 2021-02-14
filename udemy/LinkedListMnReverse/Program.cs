using System;

namespace LinkedListMnReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            sol.Traverse(sol.MNReverse(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 2, 4));
            Console.WriteLine();
            sol.Traverse(sol.MNReverse(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 1, 5));
            Console.WriteLine();
            sol.Traverse(sol.MNReverse(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 1, 3));
            Console.WriteLine();
            sol.Traverse(sol.MNReverse(new Node(1, new Node(2, new Node(3, new Node(4, new Node(5))))), 2, 5));
            Console.WriteLine();
            sol.Traverse(sol.MNReverse(new Node(1), 1, 1));
        }
    }

    public class Node
    {
        public Node(int val, Node next = null)
        {
            Val = val;
            Next = next;
        }

        public int Val { get; }

        public Node Next { get; set; }
    }


    public class Solution
    {
        public void Traverse(Node head)
        {
            var current = head;
            while (current != null)
            {
                Console.Write(current.Val + "->");
                current = current.Next;
            }
        }

        // 1 <= m <= n <= |List|
        public Node MNReverse(Node head, int m, int n)
        {
            var start = head;
            var current = head;
            int position = 1;
            while (position < m)
            {
                start = current;
                current = current.Next;
                position += 1;
            }
            var tail = current;
            var newList = default(Node);
            while (m <= position && position <= n)
            {
                var next = current.Next;
                current.Next = newList;
                newList = current;
                current = next;
                position += 1;
            }

            start.Next = newList;
            tail.Next = current;

            return (m > 1) ? head : newList;
        }
    }
}
