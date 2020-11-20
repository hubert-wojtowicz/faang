using System;
using System.Diagnostics;

namespace L5T2_GenomicRangeQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { S = "CAGCCTA", P = new[]{ 2, 5, 0 }, Q = new[] { 4, 5, 6 }, Expected = new[] { 2, 4, 1 } },
            };

            Stopwatch sw = new Stopwatch();
            foreach (var @case in cases)
            {
                sw.Restart();
                var res = sol.solution(@case.S, @case.P, @case.Q);
                sw.Stop();
                Console.WriteLine($"{string.Join(',', res)} - {(string.Join(',', res) == string.Join(',', @case.Expected) ? "CORRECT" : "FAILED")} in {sw.ElapsedMilliseconds}ms.");
            }
        }
    }

    class TestCase
    {
        public string S { get; set; }

        public int[] P { get; set; }

        public int[] Q { get; set; }

        public int[] Expected { get; set; }
    }

    /*
     * A = 1
     * C = 2
     * G = 3
     * T = 4
     * What is the minimal impact factor of nucleotides contained in a particular part of the given DNA sequence S = S[0]S[1]...S[N-1]?
     * 
     * In other words this task is to find sammest factor nucleoide of indexes i in subsequence 0 <= p <= i <= q <= M-1
     * N is an integer within the range [1..100,000];
     * M is an integer within the range [1..50,000];
     * 
     * Brute force algoritm is O(N*M) where we traverse every p-q indexes (max N) of subsequence for M subsequences; 5*10^9 operations this is not acceptable long.
     * 
     * For sure we need to act M times for eqery subsequence, so the hitch is in stating minimal nucleoide factor in subsequence.
     * 
     * This look like we can precalculate something.
     * 
     * The M nuber is relatively small so probably we need to allocate memory with some useful data.
     * 
     * And YES all we need is prefix. :) Lets define prefix as:
     * last index of particular nucleone before on in current position. If no prev occcurance put -1.
     * 
     * 
     * indexes:     0   1   2   3   4   5   6
     * factors:     2   1   3   2   2   4   1
     *              C   A   G   C   C   T   A
     *              
     * prefix : A  -1   1   1   1   1   1   6
     *          C   0   0   0   3   4   4   4
     *          G  -1  -1   2   2   2   2   2
     *          T  -1  -1  -1  -1  -1   5   5
     *
     * Having such defined prefix let us easily calculate answer question of minimal factor in following way:
     * subsequence S[p]S[p+1]...S[q-1]S[q] has the lowest factor:
     * 1 if prefix index [A][q] >= p
     * 2 if prefix index [C][q] >= p
     * 3 if prefix index [G][q] >= p
     * 4 if prefix index [T][q] >= p
     * 
     * Technical remarks:
     * - not initialize prefix by hand lets add 1 to every item. Then 0 corresponding -1.
     * - assume prefix first dimension is zero based so prefix[0,...] correspond A and prefix[3,..] corresponds T.
     */

    class Solution
    {
        public int[] solution(string S, int[] P, int[] Q)
        {
            var prefix = GetPrefix(S);

            var res = new int[P.Length];

            for (int i = 0; i < P.Length; i++)
            {
                var p = P[i];
                var q = Q[i];

                var isA = prefix[0, q] - 1 >= p;
                var isC = prefix[1, q] - 1 >= p;
                var isG = prefix[2, q] - 1 >= p;

                if (isA)
                    res[i] = 1;
                else if (isC)
                    res[i] = 2;
                else if (isG)
                    res[i] = 3;
                else // isT
                    res[i] = 4;
            }

            return res;
        }


        int[,] GetPrefix(string S)
        {
            var prefix = new int[4, S.Length];

            for (int i = 0; i < S.Length; i++)
            {
                var setIndex = (i != 0) ? i - 1 : 0;

                if (S[i] == 'A')
                {
                    prefix[0, i] = i + 1;
                    prefix[1, i] = prefix[1, setIndex];
                    prefix[2, i] = prefix[2, setIndex];
                    prefix[3, i] = prefix[3, setIndex];
                }
                else if (S[i] == 'C')
                {
                    prefix[0, i] = prefix[0, setIndex];
                    prefix[1, i] = i + 1;
                    prefix[2, i] = prefix[2, setIndex];
                    prefix[3, i] = prefix[3, setIndex];
                }
                else if (S[i] == 'G')
                {
                    prefix[0, i] = prefix[0, setIndex];
                    prefix[1, i] = prefix[1, setIndex];
                    prefix[2, i] = i + 1;
                    prefix[3, i] = prefix[3, setIndex];
                }
                else if (S[i] == 'T')
                {
                    prefix[0, i] = prefix[0, setIndex];
                    prefix[1, i] = prefix[1, setIndex];
                    prefix[2, i] = prefix[2, setIndex];
                    prefix[3, i] = i + 1;
                }
            }

            return prefix;
        }
    }
}
