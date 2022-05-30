using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int[] par = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).ToArray();
                int n = par[0];
                int x = par[1];
                int y = par[2];
                Console.WriteLine($"Case #{i + 1}: {(PossibleRatio(n, x, y) ? "POSSIBLE" : "IMPOSSIBLE")}");
            }
        }

        static bool PossibleRatio(int n, int x, int y)
        {
            int sum = n * (n + 1) / 2;
            if (sum % (x + y) != 0) return false;

            int sumx = sum * x / (x + y);
            int sumy = sum - sumx;

            return isSubsetSum(Enumerable.Range(1,n).ToArray(),n,sumx);
        }

        static bool isSubsetSum(int[] set, int n, int sum)
        {
            bool[,] subset = new bool[sum + 1, n + 1];

            for (int i = 0; i <= n; i++)
                subset[0, i] = true;

            for (int i = 1; i <= sum; i++)
                subset[i, 0] = false;

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= set[j - 1])
                        subset[i, j] = subset[i, j] || subset[i - set[j - 1], j - 1];
                }
            }

            return subset[sum, n];
        }
    }
}
