using System;
using System.Collections.Generic;

namespace _366_FindLeavesOfBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solution();
            var tree1 = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            var sol1 = solver.FindLeaves(tree1);

            Console.WriteLine("Hello World!");
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            var res = new List<List<int>>();

            GetHeight(root, ref res);

            return res.ToArray();
        }

        int GetHeight(TreeNode root, ref List<List<int>> res)
        {
            if (root == null) return -1;
            var currentHeight = Math.Max(GetHeight(root.left, ref res), GetHeight(root.right, ref res)) + 1;

            while (res.Count <= currentHeight)
            {
                res.Add(new List<int>());
            }

            res[currentHeight].Add(root.val);

            return currentHeight;
        }

        public IList<IList<int>> FindLeavesInefficient(TreeNode root)
        {
            var res = new List<List<int>>();

            while (root.left != null || root.right != null) 
            {
                var leaves = new List<int>();
                GetLeaves(root, ref leaves, null);
                res.Add(leaves);
            }
            res.Add(new List<int> { root.val });

            return res.ToArray();
        }

        public void GetLeaves(TreeNode root, ref List<int> leaves, TreeNode parent = null)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
            {
                leaves.Add(root.val);
                if (parent != null)
                {
                    parent.left = parent.left == root ? null : parent.left;
                    parent.right = parent.right == root ? null : parent.right;
                }
            }

            GetLeaves(root.left, ref leaves, root);
            GetLeaves(root.right, ref leaves, root);
        }
    }
}
