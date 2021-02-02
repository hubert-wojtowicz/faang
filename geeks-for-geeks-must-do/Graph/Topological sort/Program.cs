using System;
using System.Collections.Generic;
using System.Linq;

namespace Topological_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var jacket = new Node { Key = "jacket" };
            var watch = new Node { Key = "watch" };
            var shoes = new Node { Key = "shoes" };
            var belt = new Node { Key = "belt", Adj = new List<Node> { jacket } };
            var tie = new Node { Key = "tie", Adj = new List<Node> { jacket } };
            var trousers = new Node { Key = "trousers", Adj = new List<Node> { belt, shoes } };
            var shirt = new Node { Key = "shirt", Adj = new List<Node> { belt, tie } };
            var slips = new Node { Key = "slips", Adj = new List<Node> { trousers, shoes } };
            var socks = new Node { Key = "socks", Adj = new List<Node> { shoes } };

            var G = new DagGraph(new List<Node>
            {
                trousers, watch, jacket, tie, shirt, belt, slips, shoes, socks
            });

            foreach (var node in G.TopologicalSort())
            {
                Console.WriteLine(node.Key);
            }
        }
    }

    public class DagGraph
    {
        private int _dfsTime;

        public DagGraph(List<Node> vertives)
        {
            Vertives = vertives;

            foreach (var v in Vertives)
            {
                v.Adj ??= new List<Node>();
            }
        }

        public List<Node> Vertives { get; private set; }

        public List<Node> TopologicalSort()
        {
            Dfs();
            return Vertives.OrderByDescending(x => x.Tout).ToList();
        }

        public void Dfs()
        {
            if (!Vertives.Any())
                return;

            _dfsTime = 0;
            foreach (var v in Vertives)
            {
                v.Color = 0;
                v.Tin = 0;
                v.Tout = 0;
                v.Prev = null;
            }

            foreach (var v in Vertives)
            {
                if (v.Color == 0)
                {
                    DfsVisit(v);
                }
            }
        }

        public void DfsVisit(Node current)
        {
            current.Color = 1;
            _dfsTime++;
            current.Tin = _dfsTime;

            foreach (var v in current.Adj)
            {
                if (v.Color == 0)
                {
                    v.Prev = current;
                    DfsVisit(v);
                }
            }

            current.Color = 2;
            _dfsTime++;
            current.Tout = _dfsTime;
        }
    }

    public class Node
    {
        public int Tin { get; set; }

        public int Tout { get; set; }

        public int Color { get; set; }

        public string Key { get; set; }

        public List<Node> Adj { get; set; }

        public Node Prev { get; set; }
    }
}
