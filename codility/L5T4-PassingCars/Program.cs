using System;
using System.Diagnostics;

namespace L5T4_PassingCars
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A = new[] { 0,1,0,1,1 }, Expected = 5},
                new TestCase { A = new[] { 0 }, Expected = 0},
                new TestCase { A = new[] { 1 }, Expected = 0},
                new TestCase { A = new[] { 0,1 }, Expected = 1},
                new TestCase { A = new[] { 1,0 }, Expected = 0},
                new TestCase { A = new[] { 1,0,0 }, Expected = 0},
                new TestCase { A = new[] { 1,0,1 }, Expected = 1},
                new TestCase { A = new[] { 1,1,1 }, Expected = 0},
                new TestCase { A = new[] { 0,1,1 }, Expected = 2},
            };

            Stopwatch sw = new Stopwatch();

            foreach (var @case in cases)
            {
                sw.Restart();
                var res = sol.solution(@case.A);
                sw.Stop();
                Console.WriteLine($"{res} - {(res == @case.Expected ? "CORRECT" : "FAILED")} in {sw.ElapsedMilliseconds}ms.");
            }
        }
    }

    class TestCase
    {
        public int[] A { get; set; }

        public int Expected { get; set; }
    }

    /*
     * Array A contains only 0s and/or 1s:
     * 0 represents a car traveling east,
     * 1 represents a car traveling west.
     * 
     * We say that a pair of cars (P, Q), where 0 ≤ P < Q < N, is passing when P is traveling to the east and Q is traveling to the west.
     *   A[0] = 0
     *   A[1] = 1
     *   A[2] = 0
     *   A[3] = 1
     *   A[4] = 1
     *   We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).
     *   The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.
     *   
     *   ----
     *   What I need to do to have O(N) is for every car going east (0) value add number of cars going west that are in next array elements.
     *   We can use suffix sum to avoid O(N^2).
     *   So for every car we aggregate suffix sum as long as it does not exceeds 10^9. Otherwise immidiately return -1.
     */

    class Solution
    {
        public int solution(int[] A)
        {
            var passingCars = 0;
            var s = suffix(A);
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                    passingCars += s[i];

                if (passingCars > 1000000000)
                    return -1;
            }

            return passingCars;
        }

        int[] suffix(int[] A)
        {
            var suffix = new int[A.Length];
            var sum = 0;
            for (int i = A.Length - 1; i >= 0; --i)
            {
                sum += A[i];
                suffix[i] = sum;
            }

            return suffix;
        }
    }
}
