using System;
using System.Collections.Generic;
using System.Linq;

namespace TraverseKThreeAndPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sol = new Solution();

            var tree =
                new Node(4,
                    new Node(5,
                        new Node(4,
                            new Node(5)),
                        new Node(3)),
                    new Node(9,
                        new Node(1),
                        new Node(2)));

            sol.Traverse(tree);
        }
    }

    /*
     K-children three is given:
            4
        5       9 
       4 3     1 2
      5

    Traverse a tree and print 'yes' or 'no' for each node, depending
    if a path from this node to the root, has a permutation that is a palindrome.
    Each node's value is a digit.

    5 4 5 4 - 5 4 4 5 'yes'
    9 4 - 'no'
    */

    public class Node
    {
        public Node(int key, Node left = null, Node right = null)
        {
            Key = key;
            Children = new List<Node>();

            if (left != null)
                Children.Add(left);

            if (right != null)
                Children.Add(right);
        }

        public Node(int key, Node[] children)
        {
            Key = key;
            Children = children.ToList();
        }

        public int Key { get; set; }

        public List<Node> Children { get; set; }
    }

    public class Solution
    {
        readonly int[] _masks = new int[]
        {
            0b00000000_00000000_00000000_00000000, // 0
            0b00000000_00000000_00000000_00000001, // 1
            0b00000000_00000000_00000000_00000010, // 2
            0b00000000_00000000_00000000_00000100, // 3
            0b00000000_00000000_00000000_00001000, // 4
            0b00000000_00000000_00000000_00010000, // 5
            0b00000000_00000000_00000000_00100000, // 6
            0b00000000_00000000_00000000_01000000, // 7
            0b00000000_00000000_00000000_10000000, // 8
            0b00000000_00000000_00000001_00000000, // 9
        };

        public void Traverse(Node root)
        {
            TraverseInternal(root, _masks[root.Key]);
        }

        public void TraverseInternal(Node root, int marker = 0)
        {
            if (root == null)
                return;

            if (IsPalindrome(marker))
                Console.WriteLine($"{root.Key} yes");
            else
                Console.WriteLine($"{root.Key} no");

            for (int i = 0; i < root.Children.Count; i++)
            {
                TraverseInternal(root.Children[i],  marker ^ _masks[root.Children[i].Key]);
            }
        }

        private bool IsPalindrome(int marker)
        {
            return _masks.Contains(marker);
        }
    }
}