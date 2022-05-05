using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainReactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var root = GetThree();
                var solver = new Solution();
                Console.WriteLine($"Case #{i + 1}: {solver.Solve(root)}");
            }
        }

        private static Node GetThree()
        {
            var n = int.Parse(Console.ReadLine());
            var f = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var p = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var nodes = new Node[n + 1];
            var root = new Node() { Value = 0 };
            nodes[0] = root;
            for (int i = 1; i < n + 1; i++)
            {
                nodes[i] = new Node() { Value = f[i - 1] };
                nodes[p[i - 1]].Children.Add(nodes[i]);
            }

            return root;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
    }

    public class Solution
    {
        public int Solve(Node root)
        {
            if (root.Children.Count == 0)
                return root.Value;
            else if (root.Children.Count == 1)
                return Math.Max(Solve(root.Children.Single()), root.Value);
            else
            {
                var orderedChildren = root.Children.Select(x => (x, ans: Solve(x))).OrderBy(x => x.ans).ToList();
                return Math.Max(orderedChildren.First().ans, root.Value) + orderedChildren.Skip(1).Sum(x => x.ans);
            }
        }
    }
}
