using System;
using System.Collections.Generic;

namespace CompleteBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();


            Console.WriteLine("Hello World!");
        }
    }

    public class Node
    {
        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Key { get; set; }
    }

    public class Solution
    {
        // not working as it check only one path to leaf
        bool IsComplete(Node root)
        {
            if (root == null || (root.Left == null && root.Right != null))
                return false;
            else if (root.Left != null && root.Right != null)
            {
                IsComplete(root.Left);
                IsComplete(root.Right);
            }
            else if (root.Left != null && root.Right == null)
            {
                IsComplete(root.Left);
            }

            return true;
        }

        bool IsCompleteQueue(Node root)
        {
            if (root == null)
                return false;

            var q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                var node = q.Dequeue();

                if (node.Left != null && node.Right == null)
                {
                    return false;
                }
                else
                {
                    if (node.Left != null)
                        q.Enqueue(node.Left);
                    if (node.Right != null)
                        q.Enqueue(node.Right);
                }
            }

            return true;
        }
    }
}
