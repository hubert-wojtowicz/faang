using System;
using System.Linq;

namespace d1000000
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t;
            t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int N = int.Parse(Console.ReadLine());
                var S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
                Console.WriteLine($"Case #{i + 1}: {Solve(S)}");
            }
        }

        private static int Solve(int[] S)
        {
            int prev = 1;
            for (int i = 1; i < S.Length; i++)
            {
                prev = Math.Min(prev + 1, (S[i - 1] < S[i]) ? i + 1 : S[i - 1]);
            }

            return prev;
        }
    }
}
