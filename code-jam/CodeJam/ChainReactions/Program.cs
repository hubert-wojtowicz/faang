using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainReactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t;
            t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var N = int.Parse(Console.ReadLine());
                var F = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                var P = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                var solver = new Solution();
                Console.WriteLine($"Case #{i + 1}: {solver.Solve(F, P)}");
            }
        }

    }

    public class Solution
    {
        public int[] F { get; private set; }
        public Dictionary<int,List<int>> R { get; private set; }
        public List<int> RootIdxs { get; private set; }
        public int Total { get; set; }

        public int Solve(int[] F, int[] P)
        {
            this.F = F;
            Total = 0;
            R = new Dictionary<int, List<int>>();
            RootIdxs = new List<int>();
            for (int i = 0; i < P.Length; i++)
            {
                if (P[i] != 0)
                {
                    if (!R.ContainsKey(P[i] - 1))
                        R.Add(P[i] - 1,new List<int>() { i });
                    else
                        R[P[i] - 1].Add(i);
                }
                else
                {
                    RootIdxs.Add(i);
                }
            }

            foreach (var index in RootIdxs)
            {
                CalculateMaxBenefit(index);
            }

            return RootIdxs.Sum(rootIdx => F[rootIdx]) + Total;
        }

        void CalculateMaxBenefit(int root)
        {
            if (!R.ContainsKey(root)) return;

            foreach (var descIdx in R[root])
            {
                CalculateMaxBenefit(descIdx);
            }

            var childrenIdxs = R[root];
            var minChildIdx = childrenIdxs[0];
            if (childrenIdxs.Count > 1)
            {
                foreach (var childIdx in childrenIdxs.Skip(1))
                {
                    if (F[childIdx] < F[minChildIdx])
                        minChildIdx = childIdx;
                }
                Total += (R[root].Sum(idx => F[idx]) - F[minChildIdx]);
            }

            F[root] = Math.Max(F[root], F[minChildIdx]);
        }
    }
}
