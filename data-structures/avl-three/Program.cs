using System;
using System.Collections;
using System.Collections.Generic;

namespace avl_three
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlThree();

            tree.Insert(50);
            tree.Insert(17);
            tree.Insert(72);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);
            tree.Insert(67);

            tree.InOrderTraversal();
            Console.WriteLine($"Min value: {tree.Min()}, max value: {tree.Max()}");
            var node23 = tree.Find(23);
            Console.WriteLine($"Node 23 has " +
                $"left child of value: {(node23?.Left?.Value == null ? "X" : node23.Left.Value.ToString())}, " +
                $"right child of value: {(node23?.Right?.Value == null ? "X" : node23.Right.Value.ToString())}");

            var p9 = tree.Predecessor(9);
            var s9 = tree.Successor(9);
            Console.WriteLine($"Predecessor of 9 {(p9 == null ? "X" : p9.Value.ToString())}");
            Console.WriteLine($"Successor of 9 {(s9 == null ? "X" : s9.Value.ToString())}");
        }
    }
    public interface IPriorityQueue
    {
        void Insert(int x);
        bool Delete(int x);
        int? Min();
        int? Max();
    }

    public interface IAvlTree : IPriorityQueue
    {
        Node Root { get; set; }
        int? Successor(int x);
        int? Predecessor(int x);
        void InOrderTraversal();
    }

    public interface IMyTree : IAvlTree
    {
        Node Find(int x);
    }

    public class AvlThree : IMyTree
    {
        public Node Root { get; set; }

        public bool Delete(int x)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraversal()
        {
            Traverse(Root);
            Console.Write('\n');
        }

        private void Traverse(Node n)
        {
            if (n != null)
            {
                Traverse(n.Left);
                Console.Write(n.Value + ", ");
                Traverse(n.Right);
            }
        }

        public void Insert(int x)
        {
            //todo: balancign tree
            if (Root != null)
            {
                Insert(Root, x);
            }
            else
            {
                Root = new Node { Value = x };
            }
        }

        private void Insert(Node n, int x)
        {
            if (x < n.Value)
            {
                if (n.Left != null)
                    Insert(n.Left, x);
                else
                    n.Left = new Node { Value = x };
            }
            else
            {
                if (n.Right != null)
                    Insert(n.Right, x);
                else
                    n.Right = new Node { Value = x };
            }
        }

        public int? Max()
        {
            return Root != null ? Max(Root) : default(int?);
        }

        private int Max(Node n)
        {
            if (n.Right != null)
            {
                return Max(n.Right);
            }
            else
            {
                return n.Value;
            }
        }

        public int? Min()
        {
            return Root != null ? Min(Root) : default(int?);
        }

        private int Min(Node n)
        {
            if (n.Left != null)
            {
                return Min(n.Left);
            }
            else
            {
                return n.Value;
            }
        }

        public int? Predecessor(int x)
        {
            throw new NotImplementedException();
        }

        public int? Successor(int x)
        {
            throw new NotImplementedException();
        }

        public Node Find(int x)
        {
            return Find(Root, x);
        }

        private Node Find(Node n, int x)
        {
            if (n == null)
            {
                return null;
            }
            else if (x == n.Value)
            {
                return n;
            }
            else if (x < n.Value)
            {
                return Find(n.Left, x);
            }
            else // (n.Value < x)
            {
                return Find(n.Right, x);
            }
        }
    }

    public class Node
    {
        public int Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}
