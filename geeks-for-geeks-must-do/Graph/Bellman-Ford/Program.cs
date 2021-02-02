using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bellman_Ford
{
    static class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph(
                5,
                new (int, int)[] { (0, 1), (1, 2), (0, 2), (1, 3), (3, 1), (3, 2), (4, 3), (1, 4) },
                new int[] { -1, 3, 4, 2, 1, 5, -3, 2 });

            g.BellmanFord(0);

            Console.WriteLine(string.Join(", ", g.D));
            Console.WriteLine(string.Join(", ", g.PI));
        }
    }

    public class Graph
    {
        private readonly int _v;
        private readonly (int u, int v)[] _e;
        private readonly int[] _w;

        public int[] D => _d;
        public int?[] PI => _pi;

        private int?[] _pi;
        private int[] _d;

        public Graph(
            int v,
            (int, int)[] e,
            int[] w)
        {
            _v = v;
            _e = e;
            _w = w;
        }


        public bool BellmanFord(int source)
        {
            _d = Enumerable.Repeat(int.MaxValue, _v).ToArray();
            _pi = Enumerable.Repeat(default(int?), _v).ToArray();
            _d[source] = 0;

            for (int i = 0; i < _v - 1; i++)
            {
                for (int j = 0; j < _e.Length; j++)
                {
                    (int u, int v) = _e[j];
                    Relax(u, v, _w[j]);
                }
            }

            for (int j = 0; j < _e.Length; j++)
            {
                (int u, int v) = _e[j];
                if (_d[v] > _d[u] + _w[j])
                    return false;
            }

            return true;
        }

        private void Relax(int u, int v, int w)
        {
            if (_d[v] > _d[u] + w)
            {
                _d[v] = _d[u] + w;
                _pi[v] = u;
            }
        }
    }
}