using System;
using System.Collections.Generic;
using System.Linq;

namespace Shortest_Source_to_Destination_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            int tc = int.Parse(Console.ReadLine());
            for (int i = 0; i < tc; i++)
            {
                int[] s = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                bool[] matrix = Console.ReadLine().Split(" ").SelectMany(x => x.ToArray()).Select(x => x == '1').ToArray();
                int[] d = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
                (int x, int y) size = (s[0], s[1]);
                (int x, int y) dest = (d[0], d[1]);
                var sol = new Solution();
                Console.WriteLine(sol.MinDistanceBfs(matrix, size.x, size.y, dest.x, dest.y));
            }
        }

    }

    public class Solution
    {
        public int MinDistanceBfs(bool[] matrix, int xs, int ys, int xd, int yd)
        {
            if (matrix == null || matrix.Length == 0)
                return -1;
            else if (xs == 1 && ys == 1 && matrix[0])
                return 0;

            int vDest = P((xd, yd), ys);
            int[] color = new int[matrix.Length];
            int distance = 0;
            var q = new Queue<int>();
            q.Enqueue(0);
            color[0]++;

            while (q.Count != 0)
            {
                var v = q.Dequeue();
                foreach (var vn in GetAllPossibleSteps(matrix, color, v, xs, ys))
                {
                    if (vDest == vn)
                        return distance + 1;

                    color[vn]++;
                    q.Enqueue(vn);
                }

                distance++;
            }

            return -1;
        }


        IEnumerable<int> GetAllPossibleSteps(bool[] martrix, int[] color, int idx, int xs, int ys)
        {
            var dest = new List<int>();
            var cc = Coord(idx, ys);
            var coord = (cc.xc + 1, cc.yc);
            var p = P(coord, ys);
            if (IsInArrary(coord, xs, ys) && color[p] == 0 && martrix[p])
            {
                dest.Add(p);
            }

            coord = (cc.xc - 1, cc.yc);
            p = P(coord, ys);
            if (IsInArrary(coord, xs, ys) && color[p] == 0 && martrix[p])
            {
                dest.Add(p);
            }

            coord = (cc.xc, cc.yc + 1);
            p = P(coord, ys);
            if (IsInArrary(coord, xs, ys) && color[p] == 0 && martrix[p])
            {
                dest.Add(p);
            }

            coord = (cc.xc, cc.yc - 1);
            p = P(coord, ys);
            if (IsInArrary(coord, xs, ys) && color[p] == 0 && martrix[p])
            {
                dest.Add(p);
            }

            return dest;
        }

        public (int xc, int yc) Coord(int p, int ys) => (p / ys, p % ys);

        public int P((int x, int y) coord, int ys) => ys * coord.x + coord.y;

        bool IsInArrary((int xc, int yc) coord, int xs, int ys) => 0 <= coord.xc && coord.xc < xs && 0 <= coord.yc && coord.yc < ys;
    }
}
