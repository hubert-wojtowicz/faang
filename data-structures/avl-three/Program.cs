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
            var p12 = tree.Predecessor(12);
            var s12 = tree.Successor(12);
            Console.WriteLine($"Predecessor of 9 {(p9 == null ? "X" : p9.Value.ToString())}");
            Console.WriteLine($"Successor of 9 {(s9 == null ? "X" : s9.Value.ToString())}");
            Console.WriteLine($"Predecessor of 12 {(p12 == null ? "X" : p12.Value.ToString())}");
            Console.WriteLine($"Successor of 12 {(s12 == null ? "X" : s12.Value.ToString())}");

            tree.Delete(tree.Find(17));
        }
    }
    public interface IPriorityQueue
    {
        void Insert(Node x);
        Node Delete(Node x);
        Node Min(Node r);
        Node Max(Node r);
    }

    public interface IAvlTree : IPriorityQueue
    {
        Node Root { get; set; }
        Node Successor(Node x);
        Node Predecessor(Node x);
        void InOrderTraversal();
    }

    public interface IMyTree : IAvlTree
    {
        void Insert(int x);
        Node Successor(int x);
        Node Predecessor(int x);
        Node Find(int x);
        Node Min();
        Node Max();
    }

    public class AvlThree : IMyTree
    {
        public Node Root { get; set; }

        public Node Delete(Node z)
        {
            if (z == null)
                return null;

            // select node that will be deleted from tree
            Node y;
            if (z.Left == null || z.Right == null)
            {
                y = z;
            }
            else
            {
                y = Successor(z);
            }

            // select non-null child
            Node x;
            if (y.Left != null)
                x = y.Left;
            else
                x = y.Right;

            // if exist non-null child assign it to y
            if (x != null)
                x.Parent = y.Parent;

            if (y.Parent == null)
                Root = x;
            else
            {
                if (y == y.Parent.Left)
                    y.Parent.Left = x;
                else
                    y.Parent.Right = x;
            }
            if (y != z)
            {
                z.Value = y.Value;
            }

            return y;
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
            Insert(new Node { Value = x });
        }

        public void Insert(Node x)
        {
            if (Root != null)
            {
                Insert(Root, x);
            }
            else
            {
                Root = x;
            }
        }

        private void Insert(Node r, Node x)
        {
            if (x.Value < r.Value)
            {
                if (r.Left != null)
                    Insert(r.Left, x);
                else
                {
                    r.Left = x;
                    x.Parent = r;
                }
            }
            else
            {
                if (r.Right != null)
                    Insert(r.Right, x);
                else
                {
                    r.Right = x;
                    x.Parent = r;
                }
            }
        }

        public Node Max() => Max(Root);

        public Node Max(Node r)
        {
            if (r?.Right != null)
            {
                return Max(r.Right);
            }
            else
            {
                return r;
            }
        }

        public Node Min() => Min(Root);

        public Node Min(Node r)
        {
            if (r?.Left != null)
            {
                return Min(r.Left);
            }
            else
            {
                return r;
            }
        }

        public Node Predecessor(int x)
        {
            var xn = Find(x);
            return Predecessor(xn);
        }

        public Node Predecessor(Node x)
        {
            if (x == null)
            {
                return null;
            }

            if (x.Left != null)
            {
                return Max(x.Left);
            }

            var y = x.Parent;
            while (y != null && x == y.Left)
            {
                x = y;
                y = y.Parent;
            }

            return y;
        }

        public Node Successor(int x)
        {
            var xn = Find(x);
            return Successor(xn);
        }

        // most left element in right subtree 
        // closest ancestor whose left son is ancescor of x
        public Node Successor(Node x)
        {
            if (x == null)
            {
                return null;
            }

            if (x.Right != null)
            {
                return Min(x.Right);
            }

            var yn = x.Parent;
            while (yn != null && x == yn.Right)
            {
                x = yn;
                yn = yn.Parent;
            }

            return yn;
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

        public Node Parent { get; set; }
    }
}
