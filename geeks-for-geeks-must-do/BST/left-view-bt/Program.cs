using System;
using System.Collections.Generic;

namespace left_view_bt
{
    // inspired with https://practice.geeksforgeeks.org/problems/left-view-of-binary-tree/1
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(1,
                new Node(2,
                    null, new Node(3)),
                new Node(4,
                    null, new Node(5, new Node(6))));

            var sol = new Solution();
            Console.WriteLine(string.Join(", ", sol.PrintLeftVisible(root)));
        }
    }

    public class Node
    {
        public int Key { get; }
        public Node Left { get; }
        public Node Right { get; }
        public Node(int key, Node left = null, Node right = null)
        {
            Key = key;
            Left = left;
            Right = right;
        }
    }

    public class Solution
    {
        private int _maxDepth;

        // O(n) time, O(n) space;
        public List<int> PrintLeftVisible(Node root)
        {
            var leftVisable = new List<int>();
            _maxDepth = -1;

            Traverse(root, leftVisable);

            return leftVisable;
        }

        private void Traverse(Node sr, List<int> leftNodes, int depth = 0)
        {
            if (depth > _maxDepth)
            {
                leftNodes.Add(sr.Key);
                _maxDepth = depth;
            }
            if (sr.Left != null)
            {
                Traverse(sr.Left, leftNodes, depth + 1);
            }
            if (sr.Right != null)
            {
                Traverse(sr.Right, leftNodes, depth + 1);
            }
        }
    }
}
